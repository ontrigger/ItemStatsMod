using System;
using UnityEngine;

namespace ItemStats.ValueFormatters
{
    public class PercentageFormatter : IStatFormatter
    {
        private readonly int _decimalPlaces;
        private readonly float _scale;
        private readonly float _maxValue;
        private readonly string _color;

        public PercentageFormatter(int decimalPlaces = 1, float scale = 100f, float maxValue = 0f,
            string color = Colors.Green)
        {
            _decimalPlaces = decimalPlaces;
            _scale = scale;
            _color = color;
            _maxValue = maxValue > 0 ? maxValue : float.MaxValue;
        }

        public string Format(float value)
        {
            // color light blue
            var maxStackMessage = value > _maxValue ? "(Max Stack)".SetColor("#ADD8E6") : "";

            // amount of ###
            var trailFormatStr = new string('#', _decimalPlaces);
            var valueStr = Math.Round(value * _scale, _decimalPlaces).ToString($"0.{trailFormatStr}");
            valueStr += "%";

            return $"{valueStr.SetColor(_color)} {maxStackMessage}";
        }
    }
}