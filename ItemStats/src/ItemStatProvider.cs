using System.Collections.Generic;
using JetBrains.Annotations;
using RoR2;

namespace ItemStats
{
    internal static partial class ItemStatProvider
    {
        private static readonly Dictionary<ItemIndex, ItemStatDef> ItemDefs;

        private static readonly Dictionary<ItemIndex, ItemStatDef> CustomItemDefs;

        public static string ProvideStatsForItem(ItemIndex index, int count, [CanBeNull] StatContext context)
        {
            if (!ItemDefs.TryGetValue(index, out var itemStatDef))
            {
                CustomItemDefs.TryGetValue(index, out itemStatDef);
            }

            return itemStatDef != null ? itemStatDef.ProcessItem(count, context) : "";
        }

        internal static void AddCustomItemDef(ItemIndex idx, ItemStatDef customDef)
        {
            CustomItemDefs[idx] = customDef;
        }
    }
}