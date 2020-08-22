using System;
using ItemStats.ValueFormatters;
using UnityEngine;

namespace ItemStats.Stat
{
    public class ItemStat : IStat
    {
        //TODO: refactor
        private readonly Func<float, StatContext, float?> _formula;
        public readonly IStatFormatter Formatter;

        public ItemStat(Func<float, StatContext, float?> formula, string statText,
            IStatFormatter formatter = null, params AbstractModifier[] modifiers)
        {
            _formula = formula;
            StatText = statText;
            Formatter = formatter ?? new PercentageFormatter();
            StatModifiers = modifiers;
        }

        public string StatText { get; }
        public AbstractModifier[] StatModifiers { get; }

        public float? GetInitialStat(float count, StatContext context)
        {
            try
            {
                return _formula(count, context);
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
}