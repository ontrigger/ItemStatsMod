using System;
using System.Collections.Generic;
using System.Text;
using ItemStats.Stat;

namespace ItemStats.StatCalculation
{
    public class DefaultStatCalculationStrategy : IStatCalculationStrategy
    {
        public string ProcessItem(List<ItemStat> stats, int count)
        {
            var fullStatText = new StringBuilder();
            foreach (var stat in stats)
            {
                var m = stat.GetInitialStat(count);
                if (!m.HasValue) continue;
                var originalValue = m.Value;

                var modifiedValueSum = 0f;
                var formattedContributions = new StringBuilder();
                foreach (var statModifier in stat.StatModifiers)
                {
                    m = statModifier.GetInitialStat(originalValue);
                    if (!m.HasValue) continue;

                    var modifierContribution = (float) m - originalValue;
                    // skip modifiers that contrib less that 1% to the final value
                    if (!ContributionSignificant(modifierContribution)) continue;

                    formattedContributions.AppendLine(statModifier.Format(modifierContribution));

                    modifiedValueSum += modifierContribution;
                }

                var finalFormattedValue = stat.Format(originalValue + modifiedValueSum);

                if (stats.IndexOf(stat) == stats.Count - 1)
                {
                    // this is the last line
                    // TextMeshPro richtext modifier that allows me to align the stack counter on the right
                    fullStatText.Append($"<align=left>{stat.StatText}: {finalFormattedValue}");
                    fullStatText.Append(formattedContributions);
                }
                else
                {
                    fullStatText.AppendLine($"{stat.StatText}: {finalFormattedValue}");
                }
            }

            return fullStatText.Append($"<br><align=right>({count} stacks)").ToString();
        }

        private static bool ContributionSignificant(float contrib)
        {
            return Math.Round(contrib, 3) > 0;
        }
    }
}