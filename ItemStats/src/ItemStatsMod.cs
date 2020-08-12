using BepInEx;
using R2API;
using R2API.Utils;
using RoR2;

namespace ItemStats
{
    [BepInDependency("com.bepis.r2api")]
    [R2APISubmoduleDependency("ItemAPI")]
    [BepInPlugin("dev.ontrigger.itemstats", "ItemStats", "1.5.0")]
    public class ItemStatsMod : BaseUnityPlugin
    {
        public void Awake()
        {
            On.RoR2.UI.ItemIcon.SetItemIndex += (orig, self, newIndex, newCount) =>
            {
                orig(self, newIndex, newCount);

                var itemDef = ItemCatalog.GetItemDef(newIndex);
                if (self.tooltipProvider != null && itemDef != null)
                {
                    var itemDescription = Language.GetString(itemDef.descriptionToken);
                    itemDescription += ItemStatProvider.ProvideStatsForItem(newIndex, newCount);

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