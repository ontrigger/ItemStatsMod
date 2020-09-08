using RoR2;

namespace ItemStats.StatModification
{
    public interface IStatModifier
    {
        public float ModifyValue(float result, ItemIndex itemIndex, int statIndex, StatContext context);

        public int ModifyItemCount(int count, ItemIndex itemIndex, int statIndex, StatContext context);

        public string Format(float result, ItemIndex itemIndex, int statIndex, StatContext context);

        public bool AffectsItem(ItemIndex itemIndex, int statIndex);
    }
}