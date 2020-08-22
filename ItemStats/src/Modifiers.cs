using System;
using System.Linq;
using ItemStats.Stat;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStats
{
    public static class Modifiers
    {
        public static readonly Luck Luck;
        public static readonly TreasureCache TreasureCache;
        public static readonly TpHealingNova TpHealingNova;

        static Modifiers()
        {
            Luck = new Luck();
            TreasureCache = new TreasureCache();
            TpHealingNova = new TpHealingNova();
        }
    }

    public class Luck : AbstractModifier
    {
        protected override Func<float, StatContext, float> Func =>
            (result, ctx) => 1 - Mathf.Pow(1 - result, 1 + ctx.CountItems(ItemIndex.Clover));

        protected override IStatFormatter Formatter => new ModifierFormatter("from Luck");
    }

    public class TreasureCache : AbstractModifier
    {
        protected override Func<float, StatContext, float> Func =>
            (count, ctx) =>
            {
                return ContextProvider.GetPlayerBodiesExcept(0)
                    .Sum(body => body.CountItems(ItemIndex.TreasureCache)) + count;
            };

        protected override IStatFormatter Formatter =>
            new ModifierFormatter("from other players");
    }

    public class TpHealingNova : AbstractModifier
    {
        // TODO: fix
        protected override Func<float, StatContext, float> Func =>
            (count, ctx) => ContextProvider.GetPlayerIdToItemCountMap(ItemIndex.TPHealingNova)
                .Where(pair => pair.Key != 0)
                .Sum(pair => pair.Value) + count;

        protected override IStatFormatter Formatter =>
            new ModifierFormatter("from other players");
    }

    public abstract class AbstractModifier : IStat
    {
        protected abstract Func<float, StatContext, float> Func { get; }

        protected abstract IStatFormatter Formatter { get; }

        public float? GetInitialStat(float count, StatContext context)
        {
            return Func(count, context);
        }

        public string Format(float statValue)
        {
            return Formatter.Format(statValue);
        }
    }
}