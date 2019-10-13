using System;
using System.Collections.Generic;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStats
{
    public static partial class ItemStatProvider
    {
        private static readonly Dictionary<ItemIndex, ItemStatDef> ItemDefs;

        public static string ProvideStatsForItem(ItemIndex index, int count)
        {
            //TODO: refactor this so it isnt shit
            var itemStatDef = ItemDefs.ContainsKey(index) ? ItemDefs[index] : null;

            if (itemStatDef == null)
            {
                return "NOT IMPL";
            }

            return itemStatDef.ProcessItem(count);
        }
    }

    public class ItemStat : IStat
    {
        //TODO: refactor
        private readonly Func<float, float?> _formula;
        public readonly IStatFormatter Formatter;
        public string StatText { get; }
        public AbstractModifier[] StatModifiers { get; }


        public ItemStat(Func<float, float?> formula, string statText,
            IStatFormatter formatter = null, params AbstractModifier[] modifiers)
        {
            _formula = formula;
            StatText = statText;
            Formatter = formatter ?? new PercentageFormatter();
            StatModifiers = modifiers;
        }

        public float? GetInitialStat(float count)
        {
            try
            {
                return _formula(count);
            }
            catch (NullReferenceException e)
            {
                Debug.Log("Caught " + e);
            }

            return null;
        }

        public string Format(float statValue)
        {
            return Formatter.Format(statValue);
        }
    }

    public interface IStat
    {
        float? GetInitialStat(float count);
    }
}