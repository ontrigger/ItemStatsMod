using System;
using RoR2;
using UnityEngine;

namespace ItemStats.ValueFormatters
{
    public static class Extensions
    {
        public static string WrapIn(this string str, string start, string end = "")
        {
            return String.Concat(start, str, end);
        }

        public static string SetColor(this string str, string color)
        {
            return str.WrapIn($"<color={color}>", "</color>");
        }

        public static int CountItems(this CharacterBody body, ItemIndex index)
        {
            return body != null ? body.inventory.GetItemCount(index) : 0;
        }

        public static string FormatInt(
            this float value, string postfix = "",
            int decimals = 0, string color = Colors.Green)
        {
            return $"{Math.Round(value, decimals)}{postfix} {value:0}".SetColor(color);
        }

        public static string FormatPercentage(
            this float value, int decimalPlaces = 1,
            float scale = 100f, float maxValue = 0f,
            string color = Colors.Green)
        {
            // color light blue
            var maxStackMessage = value >= maxValue ? "(Max Stack)".SetColor("#ADD8E6") : "";
            value = Mathf.Min(value, maxValue);

            // amount of ###
            var trailFormatStr = new string('#', decimalPlaces);
            var valueStr = Math.Round(value * scale, decimalPlaces).ToString($"0.{trailFormatStr}");
            valueStr += "%";

            return $"{valueStr.SetColor(color)} {maxStackMessage}";
        }

        public static string FormatModifier(this float value, string statText = "", string color = "#FFB6C1")
        {
            var sign = value >= 0 ? "+" : "-";
            //TODO: turn color into a separate decorator and get rid of this
            var trailFormatStr = new string('#', 1);
            var valueStr = Math.Round(value * 100f, 1).ToString($"0.{trailFormatStr}");
            valueStr += "%";

            return "  " + $"{sign}{valueStr} ".SetColor(color) + statText;
        }
    }
}