using RoR2;

namespace ItemStats.StatModification
{
    public interface IStatModifier
    {
        float ModifyValue(float result, ItemIndex itemIndex, int statIndex, StatContext context);

        int ModifyItemCount(int count, ItemIndex itemIndex, int statIndex, StatContext context);

        string Format(float result, ItemIndex itemIndex, int statIndex, StatContext context);

        bool AffectsItem(ItemIndex itemIndex, int statIndex);
    }
}