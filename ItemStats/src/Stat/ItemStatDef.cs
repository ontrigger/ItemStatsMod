using System.Collections.Generic;
using ItemStats.Stat;
using ItemStats.StatCalculation;

namespace ItemStats
{
    public class ItemStatDef
    {
        public IStatCalculationStrategy StatCalculationStrategy = new DefaultStatCalculationStrategy();

        public List<ItemStat> Stats;

        // additional text that only appears on stat tooltip and not the logbook
        public string AdditionalText;

        public string ProcessItem(int count, StatContext context)
        {
            return StatCalculationStrategy.ProcessItem(Stats, count, context, AdditionalText);
        }
    }
}