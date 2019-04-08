using System;

namespace ItemStatsMod.ValueFormatters
{
    public class PercentageFormatter : IStatFormatter
    {
        private readonly int _decimalPlaces;
        private readonly float _scale;

        public PercentageFormatter(int decimalPlaces = 2, float scale = 100f)
        {
            _decimalPlaces = decimalPlaces;
            _scale = scale;
        }

        public string Format(float value)
        {
            // amount of ###
            var trailFormatStr = new string('#', _decimalPlaces);
            var valueStr = Math.Round(value * _scale, _decimalPlaces).ToString($"0.{trailFormatStr}");
            
            return $"{valueStr}%";
        }
    }
}