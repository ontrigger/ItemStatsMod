using System.Collections.Generic;
using RoR2;

namespace ItemStats
{
    public static partial class ItemStatProvider
    {
        private static readonly Dictionary<ItemIndex, ItemStatDef> ItemDefs;

        public static string ProvideStatsForItem(ItemIndex index, int count)
        {
            //TODO: refactor this so it isnt shit
            var itemStatDef = ItemDefs.ContainsKey(index) ? ItemDefs[index] : null;

            return itemStatDef == null ? "NOT IMPL" : itemStatDef.ProcessItem(count);
        }
    }
}