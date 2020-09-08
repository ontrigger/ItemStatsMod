using System.Collections.Generic;
using RoR2;

namespace ItemStats.StatModification
{
    internal static class StatModifiers
    {
        private static readonly Dictionary<ItemStatDef, List<IStatModifier>> ModifierDefs;

        static StatModifiers()
        {
            ModifierDefs = new Dictionary<ItemStatDef, List<IStatModifier>>();

            AddStatModifier(new LuckModifier());
            AddStatModifier(new TreasureCacheModifier());
        }

        public static void AddStatModifier(AbstractStatModifier modifier)
        {
            foreach (var itemIndex in modifier.AffectedItems.Keys)
            {
                var itemStatDef = ItemStatProvider.GetItemStatDef(itemIndex);
                if (itemStatDef == null)
                {
                    throw new KeyNotFoundException($"Affected ItemStatDef with ItemIndex ${itemIndex} not found");
                }

                var existingEntry = ModifierDefs[itemStatDef];
                if (existingEntry != null && !existingEntry.Contains(modifier))
                {
                    existingEntry.Add(modifier);
                }
                else
                {
                    ModifierDefs[itemStatDef] = new List<IStatModifier> {modifier};
                }
            }
        }

        public static List<IStatModifier> GetModifiersForItemIndex(ItemIndex itemIndex)
        {
            var itemStatDef = ItemStatProvider.GetItemStatDef(itemIndex);
            if (itemStatDef == null)
            {
                throw new KeyNotFoundException($"ItemStatDef with ItemIndex ${itemIndex} not found");
            }

            return ModifierDefs[itemStatDef];
        }

        public static List<IStatModifier> GetModifiersForItemDef(ItemStatDef itemStatDef)
        {
            return ModifierDefs[itemStatDef];
        }
    }

    /*public class TpHealingNova : StatModifier
    {
        // TODO: fix
        protected override Func<float, StatContext, float> ModifyValueFunc =>
            (count, ctx) => ContextProvider.GetPlayerIdToItemCountMap(ItemIndex.TPHealingNova)
                .Where(pair => pair.Key != 0)
                .Sum(pair => pair.Value) + count;

        protected override IStatFormatter FormatFunc =>
            new ModifierFormatter("from other players");
    }*/
}