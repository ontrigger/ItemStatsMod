using System;

namespace ItemStatsMod.ValueFormatters
{
    public class IntFormatter : IStatFormatter
    {
        private readonly string _prefix;

        public IntFormatter(string prefix = "")
        {
            _prefix = prefix;
        }

        public string Format(float value)
        {
            return Math.Round(value, 0) + _prefix;
        }
    }
}