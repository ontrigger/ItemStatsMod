using JetBrains.Annotations;
using RoR2;

namespace ItemStats
{
    public class StatContext
    {
        public StatContext([CanBeNull] CharacterMaster master)
        {
            Master = master;
            Inventory = master != null ? master.inventory : null;
        }

        [CanBeNull] public CharacterMaster Master { get; }
        [CanBeNull] public Inventory Inventory { get; }
    }

    public static class StatContextExtensions
    {
        public static int CountItems(this StatContext ctx, ItemIndex idx)
        {
            return ctx.Inventory != null ? ctx.Inventory.GetItemCount(idx) : 0;
        }
    }
}