using System.Collections.Generic;
using RoR2;

namespace ItemStats
{
    internal static partial class ItemStatProvider
    {
        private static readonly Dictionary<ItemIndex, ItemStatDef> ItemDefs;

        private static readonly Dictionary<ItemIndex, ItemStatDef> CustomItemDefs;

        public static string ProvideStatsForItem(ItemIndex index, int count, StatContext context)
        {
            var itemStatDef = GetItemStatDef(index);

            return itemStatDef != null ? itemStatDef.ProcessItem(index, count, context) : "";
        }

        public static void AddCustomItemDef(ItemIndex idx, ItemStatDef customDef)
        {
            CustomItemDefs[idx] = customDef;
        }

        public static ItemStatDef GetItemStatDef(ItemIndex index)
        {
            if (!ItemDefs.TryGetValue(index, out var itemStatDef)) CustomItemDefs.TryGetValue(index, out itemStatDef);

            return itemStatDef;
        }
    }
}