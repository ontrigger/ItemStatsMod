using System;
using System.Linq;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStats
{
    static class Modifiers
    {
        public static readonly Clover Clover;
        public static readonly TreasureCache TreasureCache;

        static Modifiers()
        {
            Clover = new Clover();
            TreasureCache = new TreasureCache();
        }
        /*public static readonly Modifier Clover = new Modifier(
            ModificationType.ReturnValue,
            result => 1 - Mathf.Pow(1 - result, 1 + CountItems(ItemIndex.Clover)),
            new ModifierFormatter("from Clover")
        );*/

        /*public static readonly Modifier TreasureCache = new Modifier(
            Modifier.ModificationType.ItemCount,
            count =>
            {
                Debug.Log("player body list");
                foreach (var user in LocalUserManager.readOnlyLocalUsersList)
                {
                    Debug.Log(user.cachedBody);
                    Debug.Log(user.cachedBody.CountItems(ItemIndex.TreasureCache));
                }

                return ContextProvider.GetPlayerBodiesExcept(0)
                           .Sum(body => Extensions.CountItems(body, ItemIndex.TreasureCache)) + count;
            },
            new ModifierFormatter("from other players")
        );*/
    }

    class Clover : AbstractModifier
    {
        protected override Func<float, float> Func =>
            result => 1 - Mathf.Pow(1 - result, 1 + ContextProvider.CountItems(ItemIndex.Clover));

        protected override IStatFormatter Formatter => new ModifierFormatter("from Clover");
    }

    class TreasureCache : AbstractModifier
    {
        protected override Func<float, float> Func =>
            count =>
            {
                Debug.Log("player body list");
                foreach (var user in NetworkUser.readOnlyInstancesList)
                {
                    Debug.Log(user.id.Equals(LocalUserManager.GetFirstLocalUser().currentNetworkUser.id));
                }

                return ContextProvider.GetPlayerBodiesExcept(0)
                           .Sum(body => body.CountItems(ItemIndex.TreasureCache)) + count;
            };

        protected override IStatFormatter Formatter => new ModifierFormatter("from other players");
    }

    public abstract class AbstractModifier
    {
        protected abstract Func<float, float> Func { get; }

        protected abstract IStatFormatter Formatter { get; }

        public float GetInitialStat(float count) => Func(count);

        public string Format(float statValue) => Formatter.Format(statValue);
    }
}