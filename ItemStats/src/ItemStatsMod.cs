using BepInEx;
using RoR2;

namespace ItemStats
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("dev.ontrigger.itemstats", "ItemStats", "1.3.0")]
    public class ItemStatsMod : BaseUnityPlugin
    {
        public void Awake()
        {
            // TODO: Use IL instead
            On.RoR2.UI.ItemIcon.SetItemIndex += (orig, self, newIndex, newCount) =>
            {
                orig(self, newIndex, newCount);

                var itemDef = ItemCatalog.GetItemDef(newIndex);
                if (self.tooltipProvider != null && itemDef != null)
                {
                    var itemDescription = Language.GetString(itemDef.descriptionToken);
                    itemDescription += "\n\n" + ItemStatProvider.ProvideStatsForItem(newIndex, newCount);


                    self.tooltipProvider.overrideBodyText = itemDescription;
                }
            };
        }
    }
}