using RoR2;

namespace ItemStats.Api
{
    public interface IProvidesItemStats
    {
        ItemStatDef StatDef { get; }

        ItemDef ItemDef { get; }
    }
}