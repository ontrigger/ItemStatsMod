using System.Reflection;
using Harmony;
using RoR2;
using RoR2.Mods;

namespace ItemStatsMod
{
    public class ItemStatsMod
    {
        [ModEntry("Tooltip Item Stats", "0.1", "ontrigger")]
        public static void Init()
        {
            var harmony = HarmonyInstance.Create("ontrigger.itemstats");

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(RoR2.UI.ItemIcon))]
    [HarmonyPatch("SetItemIndex")]
    class ItemIconPatch
    {
        //TODO: use a transpiler instead
        static void Postfix(RoR2.UI.ItemIcon __instance, RoR2.ItemIndex newItemIndex, int newItemCount)
        {
            var itemDef = ItemCatalog.GetItemDef(newItemIndex);
            if (__instance.tooltipProvider != null && itemDef != null)
            {
                var itemDescription = Language.GetString(itemDef.descriptionToken);
                itemDescription += "\n\n" + ItemStatProvider.ProvideStatsForItem(newItemIndex, newItemCount);
                
                __instance.tooltipProvider.overrideBodyText = itemDescription;
            }
        }
    }
}