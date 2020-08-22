using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using R2API;
using R2API.Utils;
using RoR2;
using RoR2.UI;
using HUD = On.RoR2.UI.HUD;
using ScoreboardStrip = On.RoR2.UI.ScoreboardStrip;

namespace ItemStats
{
    [BepInDependency("com.bepis.r2api")]
    [R2APISubmoduleDependency("ItemAPI")]
    [BepInPlugin("dev.ontrigger.itemstats", "ItemStats", "1.5.0")]
    public class ItemStatsMod : BaseUnityPlugin
    {
        private readonly Dictionary<ItemInventoryDisplay, CharacterMaster> _displayToMasterRef =
            new Dictionary<ItemInventoryDisplay, CharacterMaster>();

        private readonly Dictionary<ItemIcon, CharacterMaster> _iconToMasterRef =
            new Dictionary<ItemIcon, CharacterMaster>();

        public ItemStatsMod()
        {
            Logger = base.Logger;
        }

        internal new static ManualLogSource Logger { get; private set; }

        public void Awake()
        {
            HUD.Update += (orig, self) =>
            {
                orig(self);

                if (self.itemInventoryDisplay && self.targetMaster)
                {
                    _displayToMasterRef[self.itemInventoryDisplay] = self.targetMaster;
                }
            };

            ScoreboardStrip.SetMaster += (orig, self, master) =>
            {
                orig(self, master);

                if (master)
                {
                    _displayToMasterRef[self.itemInventoryDisplay] = master;
                }
            };

            On.RoR2.UI.ItemInventoryDisplay.AllocateIcons += (orig, self, count) =>
            {
                orig(self, count);

                var icons = self.GetFieldValue<List<ItemIcon>>("itemIcons");

                _displayToMasterRef.TryGetValue(self, out var masterRef);

                // naive, but not worth improving as it is not called every frame
                icons.ForEach(i => _iconToMasterRef[i] = masterRef);
            };

            On.RoR2.UI.ItemIcon.SetItemIndex += (orig, self, newIndex, newCount) =>
            {
                orig(self, newIndex, newCount);

                var itemDef = ItemCatalog.GetItemDef(newIndex);
                if (self.tooltipProvider != null && itemDef != null)
                {
                    var itemDescription = Language.GetString(itemDef.descriptionToken);

                    _iconToMasterRef.TryGetValue(self, out var master);

                    // TODO: use a pool to reduce StatContext allocations
                    itemDescription +=
                        ItemStatProvider.ProvideStatsForItem(newIndex, newCount, new StatContext(master));

                    self.tooltipProvider.overrideBodyText = itemDescription;
                }
            };

            ItemAPI.ItemDefinitions.CollectionChanged += (sender, args) =>
            {
                ItemStatProvider.BuildCustomStatDefinitions(args.NewItems);
            };
        }
    }
}