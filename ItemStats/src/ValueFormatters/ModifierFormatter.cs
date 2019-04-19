using System;

namespace ItemStats.ValueFormatters
{
    public class ModifierFormatter : IStatFormatter
    {
        private readonly string _statText;
        private readonly string _color;

        public ModifierFormatter(string statText = "", string color = "#FFB6C1")
        {
            _statText = statText;
            _color = color;
        }

        public string Format(float value)
        {
            var sign = value >= 0 ? "+" : "-";
            //TODO: turn color into a separate decorator and get rid of this
            var trailFormatStr = new string('#', 1);
            var valueStr = Math.Round(value * 100f, 1).ToString($"0.{trailFormatStr}");
            valueStr += "%";
            
            return "\n\t" + $"{sign}{valueStr} " + _statText;
        }
    }
}