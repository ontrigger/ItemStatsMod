using System.Collections.Generic;
using System.Linq;
using ItemStats.ValueFormatters;
using RoR2;

namespace ItemStats
{
    public static class ContextProvider
    {
        private static CharacterBody _localCachedBody;

        public static CharacterBody LocalCachedBody
        {
            get
            {
                if (_localCachedBody != null)
                {
                    return _localCachedBody;
                }

                var localUser = LocalUserManager.GetFirstLocalUser();
                if (localUser != null)
                {
                    _localCachedBody = localUser.cachedBody;
                    return _localCachedBody;
                }

                return null;
            }
        }

        public static int CountItems(ItemIndex item, int userId = 0)
        {
            var body = userId == 0 ? LocalCachedBody : LocalUserManager.FindLocalUser(userId).cachedBody;
            return body != null ? body.inventory.GetItemCount(item) : 0;
        }

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