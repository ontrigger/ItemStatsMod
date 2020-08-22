using System.Collections.Generic;
using ItemStats.Stat;

namespace ItemStats.StatCalculation
{
    public interface IStatCalculationStrategy
    {
        string ProcessItem(List<ItemStat> stats, int count, StatContext context);
    }
}