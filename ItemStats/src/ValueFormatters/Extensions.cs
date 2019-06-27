using System;
using RoR2;

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
    }
}