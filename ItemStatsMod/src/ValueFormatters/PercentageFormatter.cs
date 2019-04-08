using System;

namespace ItemStatsMod.ValueFormatters
{
    public class PercentageFormatter : IStatFormatter
    {
        private readonly int _decimalPlaces;
        private readonly float _scale;
        private readonly float _maxValue;

        public PercentageFormatter(int decimalPlaces = 2, float scale = 100f, float maxValue = 0f)
        {
            _decimalPlaces = decimalPlaces;
            _scale = scale;
            _maxValue = maxValue > 0 ? maxValue : float.MaxValue;
        }

        public string Format(float value)
        {
            var maxStackMessage = value > _maxValue ? "(Max Stack)" : "";

            // amount of ###
            var trailFormatStr = new string('#', _decimalPlaces);
            var valueStr = Math.Round(value * _scale, _decimalPlaces).ToString($"0.{trailFormatStr}");
            valueStr += "%";
            
            return $"{valueStr.SetColor("green")} {maxStackMessage.SetColor("blue")}";
        }
    }
}