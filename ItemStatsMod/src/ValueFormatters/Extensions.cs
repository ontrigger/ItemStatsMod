using System;

namespace ItemStatsMod.ValueFormatters
{
    public static class Extensions
    {
        public static string WrapIn(this string str, string start, string end = "")
        {
            return String.Concat(start, str, end);
        }

        public static string SetColor(this string str, string color)
        {
            return str.WrapIn($"<color=\"{color}\">", "</color>");
        }
    }
}