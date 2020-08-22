using System.Collections.Generic;
using ItemStats.Stat;
using ItemStats.StatCalculation;

namespace ItemStats
{
    public class ItemStatDef
    {
        private readonly IStatCalculationStrategy _strategy = new DefaultStatCalculationStrategy();
        public List<ItemStat> Stats;

        public string ProcessItem(int count, StatContext context)
        {
            return _strategy.ProcessItem(Stats, count, context);
        }
    }
}