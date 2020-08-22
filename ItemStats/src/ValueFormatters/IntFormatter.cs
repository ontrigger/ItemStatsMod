using System;

namespace ItemStats.ValueFormatters
{
    public class IntFormatter : IStatFormatter
    {
        private readonly int _decimals;
        private readonly string _prefix;

        public IntFormatter(string prefix = "", int decimals = 0)
        {
            _prefix = prefix;
            _decimals = decimals;
        }

        public string Format(float value)
        {
            return $"{Math.Round(value, _decimals)}{_prefix}".SetColor("green");
        }
    }
}