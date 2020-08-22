using System.Collections.Generic;
using System.Linq;
using ItemStats.ValueFormatters;
using RoR2;

namespace ItemStats
{
    public static class ContextProvider
    {
        public static Dictionary<int, int> GetPlayerIdToItemCountMap(ItemIndex index)
        {
            return LocalUserManager.readOnlyLocalUsersList
                .ToDictionary(user => user.id, user => user.cachedBody.CountItems(index));
        }

        public static IEnumerable<CharacterBody> GetPlayerBodiesExcept(int userId)
        {
            return LocalUserManager.readOnlyLocalUsersList
                .Where(user => user.id != userId)
                .Select(user => user.cachedBody);
        }
    }
}