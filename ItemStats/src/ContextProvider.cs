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
        
        public static int CountItems(ItemIndex item)
        
        {
            var body = LocalCachedBody;
            return body != null ? body.inventory.GetItemCount(item) : 0;
        }
    }
}