using System;
using ItemStatsMod.ValueFormatters;

namespace ItemStats.ValueFormatters
{
    public class FloatFormatter : IStatFormatter
    {
        private readonly string _prefix;
        private readonly int _decimalPlaces;

        public FloatFormatter(string prefix = "", int decimalPlaces = 1)
        {
            _prefix = prefix;
            _decimalPlaces = decimalPlaces;
        }

        public string Format(float value)
        {
            return $"{Math.Round(value, _decimalPlaces)}{_prefix}".SetColor("green");
        }
    }
}