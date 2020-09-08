using System;
using System.Collections.Generic;
using ItemStats.ValueFormatters;
using RoR2;

namespace ItemStats.StatModification
{
    public class HealingIncreaseModifier : AbstractStatModifier
    {
        protected override Func<float, ItemIndex, int, StatContext, float> ModifyValueFunc =>
            (result, itemIndex, itemStatIndex, context) =>
                result * (1 + context.CountItems(ItemIndex.IncreaseHealing));

        protected override Func<float, ItemIndex, int, StatContext, string> FormatFunc =>
            (result, itemIndex, itemStatIndex, ctx) => $"{result.FormatModifier()} from Rejuvenation Rack";

        public override Dictionary<ItemIndex, IEnumerable<int>> AffectedItems =>
            new Dictionary<ItemIndex, IEnumerable<int>>
            {
                [ItemIndex.Mushroom] = new[] {0},
                [ItemIndex.HealWhileSafe] = new[] {0},
                [ItemIndex.RegenOnKill] = new[] {0},
                [ItemIndex.Medkit] = new[] {0},
                [ItemIndex.Tooth] = new[] {0},
                [ItemIndex.HealOnCrit] = new[] {0},
                [ItemIndex.Seed] = new[] {0},
                [ItemIndex.Knurl] = new[] {1}
            };
    }
}