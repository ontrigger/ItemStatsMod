using System.Collections.Generic;
using ItemStats.Stat;
using ItemStats.StatCalculation;

namespace ItemStats
{
    public class ItemStatDef
    {
        public List<ItemStat> Stats;

        private readonly IStatCalculationStrategy _strategy = new DefaultStatCalculationStrategy();

        public string ProcessItem(int count)
        {
            return _strategy.ProcessItem(Stats, count);
        }
    }
}