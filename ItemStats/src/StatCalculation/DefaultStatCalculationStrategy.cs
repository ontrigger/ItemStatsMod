using System;
using System.Collections.Generic;
using System.Text;
using ItemStats.Stat;
using JetBrains.Annotations;

namespace ItemStats.StatCalculation
{
    public class DefaultStatCalculationStrategy : IStatCalculationStrategy
    {
        public string ProcessItem(List<ItemStat> stats, int count, StatContext context,
            [CanBeNull] string additionalText)
        {
            var fullStatText = new StringBuilder();
            fullStatText.Append("\n\n");

            if (additionalText != null)
            {
                fullStatText.Append(additionalText);
                fullStatText.Append("\n\n");
            }

            foreach (var stat in stats)
            {
                var m = stat.GetInitialStat(count, context);
                if (!m.HasValue) continue;
                var originalValue = m.Value;

                var modifiedValueSum = 0f;
                var formattedContributions = new StringBuilder();
                foreach (var statModifier in stat.StatModifiers)
                {
                    m = statModifier.GetInitialStat(originalValue, context);
                    if (!m.HasValue) continue;

                    var modifierContribution = (float) m - originalValue;

                    // skip modifiers that contrib less that 1% to the final value
                    if (!ContributionSignificant(modifierContribution)) continue;

                    formattedContributions.AppendLine(statModifier.Format(modifierContribution));

                    modifiedValueSum += modifierContribution;
                }

                var finalFormattedValue = stat.Format(originalValue + modifiedValueSum);

                // explicitly align left on the last line to fix the stack counter alignment
                var lastLineAlignment = stats.IndexOf(stat) == stats.Count - 1 ? "<align=left>" : "";

                fullStatText.Append(lastLineAlignment + $"{stat.StatText}: {finalFormattedValue} \n");
                // if (modifiedValueSum > 0f) fullStatText.AppendLine();
                fullStatText.Append(formattedContributions);
            }

            return fullStatText.Append($"<br><align=right>({count} stacks)").ToString();
        }

        private static bool ContributionSignificant(float contrib)
        {
            return Math.Round(contrib, 3) > 0;
        }
    }
}