using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using ItemStats.StatModification;
using R2API.Utils;
using RoR2;

namespace ItemStats
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("dev.ontrigger.itemstats", "ItemStats", "1.5.0")]
    [NetworkCompatibility(CompatibilityLevel.NoNeedForSync, VersionStrictness.DifferentModVersionsAreOk)]
    public class ItemStatsMod : BaseUnityPlugin
    {
        private ItemStatsMod()
        {
            Logger = base.Logger;
        }

        internal new static ManualLogSource Logger { get; private set; }

        public void Awake()
        {
            ItemStatProvider.Init();
            StatModifiers.Init();
            Hooks.Init();
        }

        public static void AddCustomItemStatDef(ItemIndex index, ItemStatDef customDef)
        {
            ItemStatProvider.AddCustomItemDef(index, customDef);
        }

        public static ItemStatDef GetItemStatDef(ItemIndex index)
        {
            return ItemStatProvider.GetItemStatDef(index);
        }

        public static void AddStatModifier(AbstractStatModifier modifier)
        {
            StatModifiers.AddStatModifier(modifier);
        }

        public static List<IStatModifier> GetModifiersForItemIndex(ItemIndex index)
        {
            return StatModifiers.GetModifiersForItemIndex(index);
        }

        public static List<IStatModifier> GetModifiersForItemDef(ItemStatDef itemStatDef)
        {
            return StatModifiers.GetModifiersForItemDef(itemStatDef);
        }
    }
}