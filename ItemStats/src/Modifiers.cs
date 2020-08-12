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
        public static readonly Clover Clover;
        public static readonly TreasureCache TreasureCache;
        public static readonly TpHealingNova TpHealingNova;

        static Modifiers()
        {
            Clover = new Clover();
            TreasureCache = new TreasureCache();
            TpHealingNova = new TpHealingNova();
        }
    }

    public class Clover : AbstractModifier
    {
        protected override Func<float, float> Func =>
            result => 1 - Mathf.Pow(1 - result, 1 + ContextProvider.CountItems(ItemIndex.Clover));

        protected override IStatFormatter Formatter => new ModifierFormatter("from Clover");
    }

    public class TreasureCache : AbstractModifier
    {
        protected override Func<float, float> Func =>
            count =>
            {
                return ContextProvider.GetPlayerBodiesExcept(0)
                    .Sum(body => body.CountItems(ItemIndex.TreasureCache)) + count;
            };

        protected override IStatFormatter Formatter =>
            new ModifierFormatter("from other players");
    }

    public class TpHealingNova : AbstractModifier
    {
        protected override Func<float, float> Func =>
            count => ContextProvider.GetPlayerIdToItemCountMap(ItemIndex.TPHealingNova)
                .Where(pair => pair.Key != 0)
                .Sum(pair => pair.Value) + count;

        protected override IStatFormatter Formatter =>
            new ModifierFormatter("from other players");
    }

    public abstract class AbstractModifier : IStat
    {
        protected abstract Func<float, float> Func { get; }

        protected abstract IStatFormatter Formatter { get; }

        public float? GetInitialStat(float count) => Func(count);

        public string Format(float statValue) => Formatter.Format(statValue);
    }
}