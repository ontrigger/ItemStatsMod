using System;

namespace ItemStats.ValueFormatters
{
    public class IntFormatter : IStatFormatter
    {
        private readonly string _prefix;
        private readonly int _decimals;

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