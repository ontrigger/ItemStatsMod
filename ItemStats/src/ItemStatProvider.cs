using System;
using System.Collections.Generic;
using System.Linq;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

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
            foreach (var itemStat in itemStatList)
            {
                var statValue = itemStat.GetInitialStat(count) + itemStat.GetIndividualStats(count).Sum();

                var statValueStr = itemStat.Format(statValue);

                statValueStr += itemStat.FormatSubStats(count);


                if (itemStatList.IndexOf(itemStat) == itemStatList.Count - 1)
                {
                    // this is the last line
                    // TextMeshPro richtext modifier that allows me to align the stack counter on the right
                    fullStatText += $"<align=left>{itemStat.StatText}: {statValueStr}";
                }
                else
                {
                    fullStatText += $"{itemStat.StatText}: {statValueStr}\n";
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
        public IModifier[] StatModifiers { get; }


        public ItemStat(Func<float, float> formula, string statText,
            IStatFormatter formatter = null, params IModifier[] modifiers)
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
                yield return stat.Func(originalValue) - originalValue;
            }
        }

        public string Format(float statValue)
        {
            return Formatter.Format(statValue);
        }

        public string FormatSubStats(float count)
        {
            var formattedValue = String.Empty;
            var result = _formula(count);

            foreach (var stat in StatModifiers)
            {
                var valueDiff = stat.Func(result) - result;
                Debug.Log("Value diff is " + valueDiff);
                if (Math.Round(valueDiff, 3) > 0)
                {
                    formattedValue += stat.Formatter.Format(valueDiff);
                }
            }

            return formattedValue;
        }
    }
}