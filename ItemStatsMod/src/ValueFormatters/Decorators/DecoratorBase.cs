
namespace ItemStatsMod.ValueFormatters.Decorators
{
    public abstract class DecoratorBase : IStatFormatter
    {
        protected readonly IStatFormatter _formatter;

        protected DecoratorBase(IStatFormatter formatter)
        {
            this._formatter = formatter;
        }

        public abstract string Format(float value);
    }
    
    public class ColorDecorator : DecoratorBase
    {
        private readonly string _color;

        public ColorDecorator(IStatFormatter formatter, string color = "green") : base(formatter)
        {
            _color = color;
        }

        public override string Format(float value)
        {
            return $"<color=\"{_color}\">" + _formatter.Format(value);
        }
    }
}