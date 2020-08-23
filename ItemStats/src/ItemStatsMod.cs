using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using R2API.Utils;
using RoR2;
using RoR2.UI;
using HUD = On.RoR2.UI.HUD;
using ScoreboardStrip = On.RoR2.UI.ScoreboardStrip;

namespace ItemStats
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("dev.ontrigger.itemstats", "ItemStats", "1.5.0")]
    [NetworkCompatibility(CompatibilityLevel.NoNeedForSync, VersionStrictness.DifferentModVersionsAreOk)]
    public class ItemStatsMod : BaseUnityPlugin
    {
        private readonly Dictionary<ItemInventoryDisplay, CharacterMaster> _displayToMasterRef =
            new Dictionary<ItemInventoryDisplay, CharacterMaster>();

        private readonly Dictionary<ItemIcon, CharacterMaster> _iconToMasterRef =
            new Dictionary<ItemIcon, CharacterMaster>();

        private ItemStatsMod()
        {
            Logger = base.Logger;
        }

        internal new static ManualLogSource Logger { get; private set; }

        public void Awake()
        {
            HUD.Update += HudUpdateHook;

            ScoreboardStrip.SetMaster += ScoreboardSetMasterHook;

            On.RoR2.UI.ItemInventoryDisplay.AllocateIcons += ItemDisplayAllocateIconsHook;

            On.RoR2.UI.ItemIcon.SetItemIndex += ItemIconSetItemIndexHook;
        }

        public static void AddCustomItemStatDef(ItemIndex index, ItemStatDef customDef)
        {
            ItemStatProvider.AddCustomItemDef(index, customDef);
        }

        private void ItemIconSetItemIndexHook(On.RoR2.UI.ItemIcon.orig_SetItemIndex orig, ItemIcon self,
            ItemIndex newIndex, int newCount)
        {
            orig(self, newIndex, newCount);

            var itemDef = ItemCatalog.GetItemDef(newIndex);
            if (self.tooltipProvider != null && itemDef != null)
            {
                var itemDescription = Language.GetString(itemDef.descriptionToken);

                _iconToMasterRef.TryGetValue(self, out var master);

                // TODO: use a pool to reduce StatContext allocations
                itemDescription += ItemStatProvider.ProvideStatsForItem(newIndex, newCount, new StatContext(master));

                self.tooltipProvider.overrideBodyText = itemDescription;
            }
        }

        private void ItemDisplayAllocateIconsHook(On.RoR2.UI.ItemInventoryDisplay.orig_AllocateIcons orig,
            ItemInventoryDisplay self, int count)
        {
            orig(self, count);

            var icons = self.GetFieldValue<List<ItemIcon>>("itemIcons");

            _displayToMasterRef.TryGetValue(self, out var masterRef);

            // naive, but not worth improving as it is not called every frame
            icons.ForEach(i => _iconToMasterRef[i] = masterRef);
        }

        private void ScoreboardSetMasterHook(ScoreboardStrip.orig_SetMaster orig, RoR2.UI.ScoreboardStrip self,
            CharacterMaster master)
        {
            orig(self, master);

            if (master)
            {
                _displayToMasterRef[self.itemInventoryDisplay] = master;
            }
        }

        private void HudUpdateHook(HUD.orig_Update orig, RoR2.UI.HUD self)
        {
            orig(self);

            if (self.itemInventoryDisplay && self.targetMaster)
            {
                _displayToMasterRef[self.itemInventoryDisplay] = self.targetMaster;
            }
        }
    }
}