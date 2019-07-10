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
            //TODO: refactor this so it isnt shit
            var itemStatList = ItemDefs.ContainsKey(index) ? ItemDefs[index] : null;

            if (itemStatList == null)
            {
                return "NOT IMPL";
            }

            var fullStatText = string.Empty;
            foreach (var itemStat in itemStatList)
            {
                var statValue = itemStat.GetInitialStat(count) + itemStat.GetSubStats(count).Sum();

                var statValueStr = itemStat.Format(statValue);

                // TODO: this is smart but not very readable;
                // either make getsubstat return a pair or do something better
                statValueStr += itemStat.GetSubStats(count)
                    .Zip(itemStat.StatModifiers, Tuple.Create)
                    .Aggregate("", (s, tuple) =>
                    {
                        if (Math.Round(tuple.Item1, 3) > 0)
                        {
                            return "\n" + tuple.Item2.Format(tuple.Item1);
                        }

                        return "";
                    });


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

            return $"{fullStatText}<br><align=right>({count} stacks)";
        }
    }

    public class ItemStat
    {
        //TODO: refactor
        private readonly Func<float, float> _formula;
        public readonly IStatFormatter Formatter;
        public string StatText { get; }
        public AbstractModifier[] StatModifiers { get; }


        public ItemStat(Func<float, float> formula, string statText,
            IStatFormatter formatter = null, params AbstractModifier[] modifiers)
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

        public IEnumerable<float> GetSubStats(float count)
        {
            var originalValue = GetInitialStat(count);
            foreach (var stat in StatModifiers)
            {
                yield return stat.GetInitialStat(originalValue) - originalValue;
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
                var valueDiff = stat.GetInitialStat(result) - result;
                Debug.Log("Value diff is " + valueDiff);
                if (Math.Round(valueDiff, 3) > 0)
                {
                    formattedValue += stat.Format(valueDiff);
                }
            }

            return formattedValue;
        }
    }
}