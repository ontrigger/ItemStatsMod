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
                result * (1 + context.CountItems(ItemCatalog.FindItemIndex("IncreaseHealing")));

        protected override Func<float, ItemIndex, int, StatContext, string> FormatFunc =>
            (result, itemIndex, itemStatIndex, ctx) =>
            {
                string formattedResult;
                if (itemIndex == ItemCatalog.FindItemIndex("Mushroom") || itemIndex == ItemCatalog.FindItemIndex("Tooth"))
                {
                    formattedResult = result.FormatPercentage(signed: true, color: Colors.ModifierColor);
                }
                else
                {
                    formattedResult = result.FormatInt(signed: true, color: Colors.ModifierColor, postfix: "HP");
                }

                return $"{formattedResult} from Rejuvenation Rack";
            };

        public override Dictionary<ItemIndex, IEnumerable<int>> AffectedItems =>
            new Dictionary<ItemIndex, IEnumerable<int>>
            {
                [ItemCatalog.FindItemIndex("Mushroom")] = new[] {0},
                [ItemCatalog.FindItemIndex("HealWhileSafe")] = new[] {0},
                [ItemCatalog.FindItemIndex("Medkit")] = new[] {0},
                [ItemCatalog.FindItemIndex("Tooth")] = new[] {0},
                [ItemCatalog.FindItemIndex("HealOnCrit")] = new[] {0},
                [ItemCatalog.FindItemIndex("Seed")] = new[] {0},
                [ItemCatalog.FindItemIndex("Knurl")] = new[] {1}
            };
    }
}