using System.Collections.Generic;
using R2API.Utils;
using RoR2;
using RoR2.UI;
using GenericNotification = On.RoR2.UI.GenericNotification;
using HUD = On.RoR2.UI.HUD;
using ScoreboardStrip = On.RoR2.UI.ScoreboardStrip;

namespace ItemStats
{
    internal static class Hooks
    {
        // TODO: prevent memleak
        private static readonly Dictionary<ItemInventoryDisplay, CharacterMaster> DisplayToMasterRef =
            new Dictionary<ItemInventoryDisplay, CharacterMaster>();

        private static readonly Dictionary<ItemIcon, CharacterMaster> IconToMasterRef =
            new Dictionary<ItemIcon, CharacterMaster>();

        public static void Init()
        {
            HUD.Update += HudUpdateHook;

            ScoreboardStrip.SetMaster += ScoreboardSetMasterHook;

            GenericNotification.SetItem += SetNotificationItemHook;

            On.RoR2.UI.ItemInventoryDisplay.AllocateIcons += ItemDisplayAllocateIconsHook;

            On.RoR2.UI.ItemIcon.SetItemIndex += ItemIconSetItemIndexHook;
        }

        private static void ItemIconSetItemIndexHook(On.RoR2.UI.ItemIcon.orig_SetItemIndex orig, ItemIcon self,
            ItemIndex newIndex, int newCount)
        {
            orig(self, newIndex, newCount);

            var itemDef = ItemCatalog.GetItemDef(newIndex);
            if (self.tooltipProvider != null && itemDef != null)
            {
                var itemDescription = Language.GetString(itemDef.descriptionToken);

                IconToMasterRef.TryGetValue(self, out var master);

                // TODO: use a pool to reduce StatContext allocations
                itemDescription += ItemStatsMod.GetStatsForItem(newIndex, newCount, new StatContext(master));

                self.tooltipProvider.overrideBodyText = itemDescription;
            }
        }

        private static void ItemDisplayAllocateIconsHook(On.RoR2.UI.ItemInventoryDisplay.orig_AllocateIcons orig,
            ItemInventoryDisplay self, int count)
        {
            orig(self, count);

            var icons = self.GetFieldValue<List<ItemIcon>>("itemIcons");

            DisplayToMasterRef.TryGetValue(self, out var masterRef);

            // naive, but not worth improving as it is not called every frame
            icons.ForEach(i => IconToMasterRef[i] = masterRef);
        }

        private static void ScoreboardSetMasterHook(ScoreboardStrip.orig_SetMaster orig, RoR2.UI.ScoreboardStrip self,
            CharacterMaster master)
        {
            orig(self, master);

            if (master) DisplayToMasterRef[self.itemInventoryDisplay] = master;
        }

        private static void HudUpdateHook(HUD.orig_Update orig, RoR2.UI.HUD self)
        {
            orig(self);

            if (self.itemInventoryDisplay && self.targetMaster)
                DisplayToMasterRef[self.itemInventoryDisplay] = self.targetMaster;
        }

        private static void SetNotificationItemHook(GenericNotification.orig_SetItem orig,
            RoR2.UI.GenericNotification self,
            ItemDef itemDef)
        {
            orig(self, itemDef);

            self.descriptionText.token = itemDef.descriptionToken;
        }
    }
}