using System;
using ItemStats.ValueFormatters;
using UnityEngine;

namespace ItemStats.Stat
{
    public class ItemStat : IStat
    {
        //TODO: refactor
        private readonly Func<float, float?> _formula;
        public readonly IStatFormatter formatter;
        public string StatText { get; }
        public AbstractModifier[] StatModifiers { get; }


        public ItemStat(Func<float, float?> formula, string statText,
            IStatFormatter formatter = null, params AbstractModifier[] modifiers)
        {
            _formula = formula;
            StatText = statText;
            this.formatter = formatter ?? new PercentageFormatter();
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
            return formatter.Format(statValue);
        }
    }
}