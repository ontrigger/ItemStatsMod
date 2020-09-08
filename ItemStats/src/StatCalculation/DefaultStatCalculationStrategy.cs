using System;
using System.Text;
using RoR2;

namespace ItemStats.StatCalculation
{
    public class DefaultStatCalculationStrategy : IStatCalculationStrategy
    {
        public string ProcessItem(ItemStatDef statDef, ItemIndex itemIndex, int count, StatContext context)
        {
            var fullStatText = new StringBuilder();
            fullStatText.Append("\n\n");

            if (statDef.AdditionalText != null)
            {
                fullStatText.Append(statDef.AdditionalText);
                fullStatText.Append("\n\n");
            }

            var statList = statDef.Stats;
            var modifierList = statDef.GetStatModifiers();

            for (var statIndex = 0; statIndex < statList.Count; statIndex++)
            {
                var stat = statList[statIndex];
                var m = stat.GetInitialStat(count, context);
                if (!m.HasValue) continue;
                var originalValue = m.Value;

                var lastLine = statIndex == statList.Count - 1;

                var modifiedValueSum = 0f;
                var formattedContributions = new StringBuilder();

                foreach (var statModifier in modifierList)
                {
                    if (!statModifier.AffectsItem(itemIndex, statIndex)) continue;

                    m = statModifier.ModifyValue(originalValue, itemIndex, statIndex, context);

                    var modifierContribution = (float) m - originalValue;

                    // skip modifiers that contrib less that 1% to the final value
                    if (!ContributionSignificant(modifierContribution)) continue;

                    formattedContributions.AppendLine();
                    formattedContributions.Append(
                        statModifier.Format(modifierContribution, itemIndex, statIndex, context)
                    );

                    modifiedValueSum += modifierContribution;
                }

                var finalFormattedValue = stat.Format(originalValue + modifiedValueSum, context);

                // explicitly align left on the last line to fix the stack counter alignment
                var lastLineAlignment = lastLine ? "<align=left>" : "";

                fullStatText.Append(lastLineAlignment + finalFormattedValue);
                if (!lastLine) fullStatText.Append("\n");
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