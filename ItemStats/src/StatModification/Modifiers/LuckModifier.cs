using System;
using System.Collections.Generic;
using System.Text;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStats.StatModification
{
    public class LuckModifier : AbstractStatModifier
    {
        protected override Func<float, ItemIndex, int, StatContext, float> ModifyValueFunc =>
            (result, itemIndex, itemStatIndex, context) =>
            {
                // if chance is already >= 100% then return same value so
                // that there are no contribution stats
                if (result >= 1)
                {
                    return result;
                }

                var cloverCount = context.CountItems(ItemCatalog.FindItemIndex("Clover"));
                var purityCount = context.CountItems(ItemCatalog.FindItemIndex("LunarBadLuck"));

                var luck = cloverCount - purityCount;
                if (luck > 0)
                {
                    return 1 - Mathf.Pow(1 - result, 1 + luck);
                }

                return (float) Math.Round(Math.Pow(result, 1 + Math.Abs(luck)), 4);
            };

        protected override Func<float, ItemIndex, int, StatContext, string> FormatFunc =>
            (result, itemIndex, itemStatIndex, ctx) =>
            {
                // TODO: pass the original value to be able to properly show clover and purity contribution
                var itemCount = ctx.CountItems(itemIndex);
                if (itemCount <= 0)
                {
                    return $"{result.FormatPercentage(signed: true, color: Colors.ModifierColor)} from luck";
                }

                var itemStatDef = ItemStatsMod.GetItemStatDef(itemIndex);
                var itemStat = itemStatDef.Stats[itemStatIndex];

                // ReSharper disable once PossibleInvalidOperationException
                var originalValue = Mathf.Clamp01(itemStat.GetInitialStat(itemCount, ctx).Value);

                var cloverCount = ctx.CountItems(ItemCatalog.FindItemIndex("Clover"));
                var purityCount = ctx.CountItems(ItemCatalog.FindItemIndex("LunarBadLuck"));

                var cloverContribution = 1 - Mathf.Pow(1 - originalValue, 1 + cloverCount) - originalValue;

                var purityContribution =
                    (float) Math.Round(Mathf.Pow(originalValue, 1 + purityCount), 3) - originalValue;

                var stringBuilder = new StringBuilder();

                if (cloverCount > 0)
                {
                    stringBuilder
                        .Append(cloverContribution.FormatPercentage(signed: true, color: Colors.ModifierColor))
                        .Append(" from Clover");

                    if (purityCount > 0) stringBuilder.AppendLine().Append("  ");
                }

                if (purityCount > 0)
                {
                    stringBuilder
                        .Append(purityContribution.FormatPercentage(signed: true, color: Colors.ModifierColor))
                        .Append(" from Purity");
                }

                return stringBuilder.ToString();
            };

        public override Dictionary<ItemIndex, IEnumerable<int>> AffectedItems =>
            new Dictionary<ItemIndex, IEnumerable<int>>
            {
                [ItemCatalog.FindItemIndex("GhostOnKill")] = new[] {1},
                [ItemCatalog.FindItemIndex("StunChanceOnHit")] = new[] {0},
                [ItemCatalog.FindItemIndex("BleedOnHit")] = new[] {0},
                [ItemCatalog.FindItemIndex("GoldOnHit")] = new[] {1},
                [ItemCatalog.FindItemIndex("ChainLightning")] = new[] {2},
                [ItemCatalog.FindItemIndex("BounceNearby")] = new[] {0},
                [ItemCatalog.FindItemIndex("StickyBomb")] = new[] {0},
                [ItemCatalog.FindItemIndex("Missile")] = new[] {1},
                [ItemCatalog.FindItemIndex("BonusGoldPackOnKill")] = new[] {1},
                [ItemCatalog.FindItemIndex("Incubator")] = new[] {0},
                [ItemCatalog.FindItemIndex("FireballsOnHit")] = new[] {1}
            };
    }
}