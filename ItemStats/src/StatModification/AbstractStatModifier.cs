using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;

namespace ItemStats.StatModification
{
    public abstract class AbstractStatModifier : IStatModifier
    {
        protected abstract Func<float, ItemIndex, int, StatContext, float> ModifyValueFunc { get; }

        protected virtual Func<int, ItemIndex, int, StatContext, int> ModifyItemCountFunc =>
            (itemCount, itemIndex, itemStatIndex, context) => itemCount;

        protected abstract Func<float, ItemIndex, int, StatContext, string> FormatFunc { get; }

        public abstract Dictionary<ItemIndex, IEnumerable<int>> AffectedItems { get; }

        public float ModifyValue(float result, ItemIndex itemIndex, int statIndex, StatContext context)
        {
            return ModifyValueFunc(result, itemIndex, statIndex, context);
        }

        public int ModifyItemCount(int count, ItemIndex itemIndex, int statIndex, StatContext context)
        {
            return ModifyItemCountFunc(count, itemIndex, statIndex, context);
        }

        public string Format(float result, ItemIndex itemIndex, int statIndex, StatContext context)
        {
            return FormatFunc(result, itemIndex, statIndex, context);
        }

        public bool AffectsItem(ItemIndex itemIndex, int statIndex)
        {
            var affectedStats = AffectedItems[itemIndex];

            return affectedStats != null && affectedStats.Contains(statIndex);
        }
    }
}