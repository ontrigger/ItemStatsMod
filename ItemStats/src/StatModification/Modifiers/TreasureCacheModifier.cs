using System;
using System.Collections.Generic;
using System.Linq;
using ItemStats.ValueFormatters;
using RoR2;

namespace ItemStats.StatModification
{
    public class TreasureCacheModifier : AbstractStatModifier
    {
        protected override Func<float, ItemIndex, int, StatContext, float> ModifyValueFunc =>
            (result, itemIndex, itemStatIndex, context) => result;

        protected override Func<int, ItemIndex, int, StatContext, int> ModifyItemCountFunc =>
            (itemCount, itemIndex, itemStatIndex, context) =>
            {
                return ContextProvider.GetPlayerBodiesExcept(0)
                    .Sum(body => body.CountItems(ItemIndex.TreasureCache)) + itemCount;
            };

        protected override Func<float, ItemIndex, int, StatContext, string> FormatFunc { get; } =
            (result, itemIndex, itemStatIndex, ctx) =>
                $"{result.FormatInt(signed: true, color: Colors.ModifierColor)} from other players";

        public override Dictionary<ItemIndex, IEnumerable<int>> AffectedItems =>
            new Dictionary<ItemIndex, IEnumerable<int>> {[ItemIndex.TreasureCache] = new[] {0, 1, 2}};
    }
}