using ItemStatsMod.ValueFormatters;
using ItemStatsMod.ValueFormatters.Decorators;

namespace ItemStats.ValueFormatters.Decorators
{
    public class ModifierDecorator : DecoratorBase
    {
        public ModifierDecorator(IStatFormatter formatter) : base(formatter)
        {
        }

        public override string Format(float value)
        {
            return "\n\t" + _formatter.Format(value);
        }
    }
}