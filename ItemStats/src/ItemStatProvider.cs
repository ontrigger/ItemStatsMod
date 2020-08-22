using System.Collections;
using System.Collections.Generic;
using ItemStats.Api;
using JetBrains.Annotations;
using RoR2;

namespace ItemStats
{
    public static partial class ItemStatProvider
    {
        private static readonly Dictionary<ItemIndex, ItemStatDef> ItemDefs;

        private static readonly Dictionary<ItemIndex, ItemStatDef> CustomItemDefs;

        public static string ProvideStatsForItem(ItemIndex index, int count, [CanBeNull] StatContext context)
        {
            if (!ItemDefs.TryGetValue(index, out var itemStatDef)) CustomItemDefs.TryGetValue(index, out itemStatDef);

            return itemStatDef != null ? itemStatDef.ProcessItem(count, context) : "";
        }

        public static void BuildCustomStatDefinitions(IList customItems)
        {
            CustomItemDefs.Clear();
            foreach (var customItem in customItems)
                if (customItem is IProvidesItemStats customProvider)
                    CustomItemDefs.Add(customProvider.ItemDef.itemIndex, customProvider.StatDef);
        }
    }
}