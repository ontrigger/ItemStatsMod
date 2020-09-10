using System;
using System.Collections.Generic;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStats.StatModification
{
    public class LuckModifier : AbstractStatModifier
    {
        protected override Func<float, ItemIndex, int, StatContext, float> ModifyValueFunc =>
            (result, itemIndex, itemStatIndex, context) =>
                1 - Mathf.Pow(1 - result, 1 + context.CountItems(ItemIndex.Clover));

        protected override Func<float, ItemIndex, int, StatContext, string> FormatFunc =>
            (result, itemIndex, itemStatIndex, ctx) =>
                $"{result.FormatPercentage(signed: true, color: Colors.ModifierColor)} from luck";

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
                [ItemIndex.Bear] = new[] {0}
            };
    }
}