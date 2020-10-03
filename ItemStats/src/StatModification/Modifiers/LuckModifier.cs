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
                var cloverCount = context.CountItems(ItemIndex.Clover);
                var purityCount = context.CountItems(ItemIndex.LunarBadLuck);

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
                if (itemCount > 0)
                {
                    var itemStatDef = ItemStatsMod.GetItemStatDef(itemIndex);
                    var itemStat = itemStatDef.Stats[itemStatIndex];

                    // ReSharper disable once PossibleInvalidOperationException
                    var originalValue = itemStat.GetInitialStat(itemCount, ctx).Value;

                    var cloverCount = ctx.CountItems(ItemIndex.Clover);
                    var purityCount = ctx.CountItems(ItemIndex.LunarBadLuck);

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
                }

                return $"{result.FormatPercentage(signed: true, color: Colors.ModifierColor)} from luck";
            };

        public override Dictionary<ItemIndex, IEnumerable<int>> AffectedItems =>
            new Dictionary<ItemIndex, IEnumerable<int>>
            {
                [ItemIndex.GhostOnKill] = new[] {1},
                [ItemIndex.StunChanceOnHit] = new[] {0},
                [ItemIndex.BleedOnHit] = new[] {0},
                [ItemIndex.GoldOnHit] = new[] {1},
                [ItemIndex.ChainLightning] = new[] {2},
                [ItemIndex.BounceNearby] = new[] {1},
                [ItemIndex.StickyBomb] = new[] {0},
                [ItemIndex.Missile] = new[] {1},
                [ItemIndex.BonusGoldPackOnKill] = new[] {1},
                [ItemIndex.Incubator] = new[] {0},
                [ItemIndex.FireballsOnHit] = new[] {1}
            };
    }
}