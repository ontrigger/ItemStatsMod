using RoR2;

namespace ItemStats.StatCalculation
{
    public interface IStatCalculationStrategy
    {
        string ProcessItem(ItemStatDef statDef, ItemIndex itemIndex, int count, StatContext context);
    }
}