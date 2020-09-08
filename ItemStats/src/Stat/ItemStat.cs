using System;

namespace ItemStats.Stat
{
    public class ItemStat : IStat
    {
        public Func<float, StatContext, float?> Formula { get; }
        public Func<float, StatContext, string> Formatter { get; }

        public ItemStat(Func<float, StatContext, float?> formula, Func<float, StatContext, string> formatter)
        {
            Formula = formula;
            Formatter = formatter;
        }

        public float? GetInitialStat(float count, StatContext context)
        {
            try
            {
                return Formula(count, context);
            }
            catch (NullReferenceException e)
            {
                ItemStatsMod.Logger.LogError("Caught " + e);
            }

            return null;
        }

        public string Format(float statValue, StatContext context)
        {
            return Formatter(statValue, context);
        }
    }
}