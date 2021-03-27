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
        }

        public static void Init()
        {
            AddStatModifier(new LuckModifier());
            AddStatModifier(new HealingIncreaseModifier());
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

                if (ModifierDefs.TryGetValue(itemStatDef, out var existingEntry))
                {
                    if (!existingEntry.Contains(modifier))
                    {
                        existingEntry.Add(modifier);
                    }
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

            return GetModifiersForItemDef(itemStatDef);
        }

        public static List<IStatModifier> GetModifiersForItemDef(ItemStatDef itemStatDef)
        {
            ModifierDefs.TryGetValue(itemStatDef, out var existingEntry);
            return existingEntry ?? new List<IStatModifier>();
        }
    }
}