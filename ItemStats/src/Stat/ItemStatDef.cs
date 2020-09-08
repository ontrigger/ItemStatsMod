using System.Collections.Generic;
using ItemStats.Stat;
using ItemStats.StatCalculation;
using ItemStats.StatModification;
using RoR2;

namespace ItemStats
{
    public class ItemStatDef
    {
        public IStatCalculationStrategy StatCalculationStrategy = new DefaultStatCalculationStrategy();

        public List<ItemStat> Stats;

        // additional text that only appears on stat tooltip and not the logbook
        public string AdditionalText;

        public string ProcessItem(ItemIndex index, int count, StatContext context)
        {
            return StatCalculationStrategy.ProcessItem(this, index, count, context);
        }
    }

    public static class ItemStatDefExtensions
    {
        public static List<IStatModifier> GetStatModifiers(this ItemStatDef statDef)
        {
            return StatModifiers.GetModifiersForItemDef(statDef);
        }
    }
}