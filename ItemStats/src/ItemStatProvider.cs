using System;
using System.Collections.Generic;
using System.Linq;
using ItemStats.ValueFormatters;
using ItemStats.ValueFormatters.Decorators;
using ItemStatsMod.ValueFormatters;
using RoR2;
using UnityEngine;
using static ItemStats.ContextProvider;
using Console = RoR2.Console;

namespace ItemStats
{
    public static partial class ItemStatProvider
    {
        private static readonly Dictionary<ItemIndex, List<ItemStat>> ItemDefs;

        public static string ProvideStatsForItem(ItemIndex index, int count)
        {
            var itemStatList = ItemDefs.ContainsKey(index) ? ItemDefs[index] : null;

            if (itemStatList == null)
            {
                return "NOT IMPL";
            }

            var fullStatText = string.Empty;
            foreach (ItemStat subItemStat in itemStatList)
            {
                var statValue = subItemStat.GetInitialStat(count) + subItemStat.GetIndividualStats(count).Sum();

                var statValueStr = subItemStat.Format(statValue);

                statValueStr += subItemStat.FormatSubStats(count);


                if (itemStatList.IndexOf(subItemStat) == itemStatList.Count - 1)
                {
                    // this is the last line
                    // TextMeshPro richtext modifier that allows me to align the stack counter on the right
                    fullStatText += $"<align=left>{subItemStat.StatText}: {statValueStr}<line-height=0>";
                }
                else
                {
                    fullStatText += $"{subItemStat.StatText}: {statValueStr}\n";
                }
            }

            return $"{fullStatText}\n<align=right>({count} stacks)<line-height=1em>";
        }
    }

    public class ItemStat
    {
        private readonly Func<float, float> _formula;
        public readonly IStatFormatter Formatter;
        public string StatText { get; }
        private Modifier[] StatModifiers { get; }


        public ItemStat(Func<float, float> formula, string statText,
            IStatFormatter formatter = null, params Modifier[] modifiers)
        {
            _formula = formula;
            StatText = statText;
            Formatter = formatter ?? new PercentageFormatter();
            StatModifiers = modifiers;
        }

        public float GetInitialStat(float count)
        {
            return _formula(count);
        }

        public IEnumerable<float> GetIndividualStats(float count)
        {
            var originalValue = GetInitialStat(count);
            foreach (var stat in StatModifiers)
            {
                yield return stat.GetModifiedValue(originalValue) - originalValue;
            }
        }

        public string Format(float statValue)
        {
            return Formatter.Format(statValue);
        }

        public string FormatSubStats(float count)
        {
            var originalValue = _formula(count);

            var formattedValue = String.Empty;
            foreach (var stat in StatModifiers)
            {
                var valueDiff = stat.GetModifiedValue(originalValue) - originalValue;
                Debug.Log("Value diff is " + valueDiff);
                if (Math.Round(valueDiff, 3) > 0)
                {
                    formattedValue += stat.GetFormattedValue(valueDiff);
                }
            }

            return formattedValue;
        }
    }

    static class Modifiers
    {
        public static readonly Modifier Clover = new Modifier(
            result => 1 - Mathf.Pow(1 - result, 1 + CountItems(ItemIndex.Clover)),
            new ModifierFormatter("from Clover")
        );
    }

    public class Modifier
    {
        private readonly Func<float, float> _func;
        private readonly IStatFormatter _formatter;

        public Modifier(Func<float, float> func, IStatFormatter formatter)
        {
            _func = func;
            _formatter = formatter;
        }

        public float GetModifiedValue(float originalValue)
        {
            return _func(originalValue);
        }

        public string GetFormattedValue(float value)
        {
            return _formatter.Format(value);
        }
    }
}