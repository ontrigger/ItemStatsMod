using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using ItemStats.StatModification;
using R2API.Utils;
using RoR2;

namespace ItemStats
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("dev.ontrigger.itemstats", "ItemStats", "2.1.0")]
    [NetworkCompatibility(CompatibilityLevel.NoNeedForSync, VersionStrictness.DifferentModVersionsAreOk)]
    public class ItemStatsMod : BaseUnityPlugin
    {
        internal new static ManualLogSource Logger { get; private set; }

        public static ConfigEntry<bool> DetailedPickupDescriptions;

        private ItemStatsMod()
        {
            Logger = base.Logger;
        }

        public void Awake()
        {
            InitConfig();

            ItemCatalog.availability.CallWhenAvailable(() =>
            {
                ItemStatProvider.Init();
                StatModifiers.Init();
                Hooks.Init();
            });
        }

        private void InitConfig()
        {
            DetailedPickupDescriptions = Config.Bind(
                "Settings",
                "DetailedPickupDescriptions",
                true,
                "Toggle displaying full item descriptions in the pickup popup"
            );
        }

        public static void AddCustomItemStatDef(ItemIndex index, ItemStatDef customDef)
        {
            ItemStatProvider.AddCustomItemDef(index, customDef);
        }

        public static ItemStatDef GetItemStatDef(ItemIndex index)
        {
            return ItemStatProvider.GetItemStatDef(index);
        }

        public static string GetStatsForItem(ItemIndex index, int count, StatContext context)
        {
            return ItemStatProvider.ProvideStatsForItem(index, count, context);
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