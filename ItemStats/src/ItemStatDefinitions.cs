using System.Collections.Generic;
using ItemStats.Stat;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStats
{
    internal partial class ItemStatProvider
    {
        static ItemStatProvider()
        {
            CustomItemDefs = new Dictionary<ItemIndex, ItemStatDef>();

            ItemDefs = new Dictionary<ItemIndex, ItemStatDef>();
        }

        public static void Init()
        {
            ItemDefs[ItemCatalog.FindItemIndex("Bear")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f - 1f / (0.15f * itemCount + 1f),
                        (value, ctx) => $"Block Chance: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Hoof")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.14f,
                        (value, ctx) => $"Movement Speed Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Syringe")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.15f,
                        (value, ctx) => $"Attack Speed Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Mushroom")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.0225f + 0.0225f * itemCount,
                        (value, ctx) => $"Healing Per Second: {value.FormatPercentage(maxValue: 1f)}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 1.5f + 1.5f * itemCount,
                        (value, ctx) => $"Area Increase: {value.FormatInt("m")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("CritGlasses")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.1f,
                        (value, ctx) => $"Additional Crit Chance: {value.FormatPercentage(maxValue: 1f)}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Feather")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Total Additional Jumps: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Seed")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Total Heal: {value.FormatInt("HP")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("GhostOnKill")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 30f,
                        (value, ctx) => $"Ghost Duration: {value.FormatInt("s")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.07f,
                        (value, ctx) => $"Proc Chance: {value.FormatPercentage()}"
                        // StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Knurl")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 40f,
                        (value, ctx) => $"Bonus Health: {value.FormatInt("HP")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 1.6f,
                        (value, ctx) => $"Additional Regeneration: {value.FormatInt("HP/s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Clover")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Additional Rerolls: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Medkit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) =>
                            20f + 0.05f * itemCount * (ctx.Master != null ? ctx.Master.GetBody().maxHealth : 1),
                        (value, ctx) =>
                        {
                            var statValue = ctx.Master != null
                                ? $"{value.FormatInt("HP")}"
                                : $"{value.FormatPercentage()}";
                            return "Health Healed: " + statValue;
                        })
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Crowbar")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.75f * itemCount,
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Tooth")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.02f * itemCount,
                        (value, ctx) => $"Heal Amount: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Talisman")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2f + itemCount * 2f,
                        (value, ctx) => $"Cooldown Reduction: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Bandolier")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f - 1f / Mathf.Pow(itemCount + 1, 0.33f),
                        (value, ctx) => $"Drop Chance: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("IceRing")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2.5f * itemCount,
                        (value, ctx) => $"Ice Blast Damage: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Ice Debuff Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("FireRing")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Fire Tornado Damage: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("WarCryOnMultiKill")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2f + 4f * itemCount,
                        (value, ctx) => $"Frenzy Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("SprintOutOfCombat")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.3f,
                        (value, ctx) => $"Speed Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("StunChanceOnHit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f - 1f / (0.05f * itemCount + 1f),
                        (value, ctx) => $"Stun Chance Increase: {value.FormatPercentage(maxValue: 1f)}"
                        //  StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("WarCryOnCombat")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2f + 4f * itemCount,
                        (value, ctx) => $"Frenzy Duration: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("SecondarySkillMagazine")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Bonus Stock: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("UtilitySkillMagazine")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 2f,
                        (value, ctx) => $"Bonus Charges: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("AutoCastEquipment")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f - (0.5f * Mathf.Pow(0.85f, itemCount - 1)),
                        (value, ctx) => $"Cooldown Decrease: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("KillEliteFrenzy")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 4f,
                        (value, ctx) => $"Frenzy Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("BossDamageBonus")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.2f + 0.2f * (itemCount - 1),
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ExplodeOnDeath")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 12f + 2.4f * (itemCount - 1f),
                        (value, ctx) => $"Radius Increase: {value.FormatInt("m")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 3.5f * (1f + (itemCount - 1) * 0.8f),
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("HealWhileSafe")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Bonus Health Regen: {value.FormatInt("HP/s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("IgniteOnKill")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 8f + 4f * itemCount,
                        (value, ctx) => $"Radius Increase: {value.FormatInt("m")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 1.5f + 1.5f * itemCount,
                        (value, ctx) => $"Duration Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("WardOnLevel")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 8f + 8f * itemCount,
                        (value, ctx) => $"Radius Increase: {value.FormatInt("m")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("NovaOnHeal")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Soul Energy: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("HealOnCrit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 4f + itemCount * 4f,
                        (value, ctx) => $"Health per Crit: {value.FormatInt("HP")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("BleedOnHit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.1f * itemCount,
                        (value, ctx) => $"Bleed Chance Increase: {value.FormatPercentage(maxValue: 1f)}"
                        // StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("SlowOnHit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2 * itemCount,
                        (value, ctx) => $"Slow Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("EquipmentMagazine")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Bonus Charges: {value.FormatInt()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 1 - Mathf.Pow(0.85f, itemCount),
                        (value, ctx) => $"Cooldown Decrease: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("GoldOnHit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        //TODO: make run a modifier
                        (itemCount, ctx) => itemCount * 2f * Run.instance.difficultyCoefficient,
                        (value, ctx) => $"Gold per Hit(*): {value.FormatInt()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.3f,
                        (value, ctx) => $"Proc Chance: {value.FormatPercentage()}"
                        // modifiers: StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("IncreaseHealing")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Healing Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("PersonalShield")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.08f * itemCount,
                        (value, ctx) => $"Shield Health Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ChainLightning")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 2f,
                        (value, ctx) => $"Total Bounces: {value.FormatInt()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 20f + 2f * itemCount,
                        (value, ctx) => $"Bounce Range: {value.FormatInt("m")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.25f,
                        (value, ctx) => $"Proc Chance: {value.FormatPercentage()}"
                        // StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("TreasureCache")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Unlockable Caches: {value}"
                        // StatModifiers.TreasureCache
                    ),
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("BounceNearby")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f - 100f / (100f + 20f * itemCount),
                        (value, ctx) => $"Hook Chance: {value.FormatPercentage()}"
                        // modifiers: StatModifiers.Luck
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 5f + itemCount * 5f,
                        (value, ctx) => $"Max Enemies Hooked: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("SprintBonus")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.25f * itemCount,
                        (value, ctx) => $"Speed Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("SprintArmor")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 30f * itemCount,
                        (value, ctx) => $"Sprint Bonus Armor: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ShockNearby")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2f * itemCount,
                        (value, ctx) => $"Total Bounces: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("BeetleGland")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Total Guards: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ShieldOnly")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.5f + (itemCount - 1) * 0.25f,
                        (value, ctx) => $"Max Health Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("StickyBomb")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.05f * itemCount,
                        (value, ctx) => $"Proc Chance Increase: {value.FormatPercentage(maxValue: 1f)}"
                        // StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("RepeatHeal")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    //TODO: need to get masters maxhealth to get actual heal amount
                    new ItemStat(
                        (itemCount, ctx) => 0.1f / itemCount,
                        (value, ctx) => $"Health Fraction/s: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Healing per Heal Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("HeadHunter")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f + 5f * itemCount,
                        (value, ctx) => $"Empowerment Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ExtraLife")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Extra Lives: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("AlienHead")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1 - Mathf.Pow(0.75f, itemCount),
                        (value, ctx) => $"Cooldown Reduction: {value.FormatPercentage(2)}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Firework")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 4 + itemCount * 4,
                        (value, ctx) => $"Firework Count: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Missile")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3 * itemCount,
                        (value, ctx) => $"Missile Total Damage: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.1f,
                        (value, ctx) => $"Proc Chance: {value.FormatPercentage()}"
                        // StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Infusion")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 100 * itemCount,
                        (value, ctx) => $"Max Additional Health: {value.FormatInt("HP")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Health Gained Per Kill: {value.FormatInt("HP")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("AttackSpeedOnCrit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.12f + 0.24f * itemCount,
                        (value, ctx) => $"Max Attack Speed: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.05f,
                        (value, ctx) => $"Crit Chance Bonus: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Icicle")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f + 3f * itemCount,
                        (value, ctx) => $"Radius: {value.FormatInt("m")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Behemoth")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1.5f + 2.5f * itemCount,
                        (value, ctx) => $"Explosion Radius: {value.FormatInt("m", 1)}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("BarrierOnKill")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 15f * itemCount,
                        (value, ctx) => $"Barrier Health: {value.FormatInt("HP")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("BarrierOnOverHeal")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.5f * itemCount,
                        (value, ctx) => $"Barrier From Overheal: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ExecuteLowHealthElite")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1 - 1 / (1 + 0.13f * itemCount),
                        (value, ctx) => $"Kill Health Threshold: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("EnergizedOnEquipmentUse")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 8f + 4f * (itemCount - 1),
                        (value, ctx) => $"Attack Speed Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("TitanGoldDuringTP")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Health Boost: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.5f + 0.5f * itemCount,
                        (value, ctx) => $"Damage Boost: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("SprintWisp")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Damage Boost: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Dagger")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1.5f * itemCount,
                        (value, ctx) => $"Dagger Damage: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("LunarUtilityReplacement")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Skill Duration: {value.FormatInt("s")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) =>
                        {
                            var healthFraction = ctx.Master != null ? ctx.Master.GetBody().maxHealth : 1;

                            // heal 1.3% of max HP per 5 times/s across 3 * itemCount seconds
                            return healthFraction * 0.013f * 5 * (3f * itemCount);
                        },
                        (value, ctx) =>
                        {
                            var statValue = ctx.Master != null
                                ? $"{value.FormatInt("HP")}"
                                : $"{value.FormatPercentage()}";
                            return "Health Healed: " + statValue;
                        })
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("NearbyDamageBonus")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.2f * itemCount,
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("TPHealingNova")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Max Occurrences: {value.FormatInt()}"
                        // StatModifiers.TpHealingNova
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ArmorReductionOnHit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 8f * itemCount,
                        (value, ctx) => $"Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Thorns")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 5 + 2 * (itemCount - 1),
                        (value, ctx) => $"Max Targets: {value.FormatInt()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 25f + 10f * (itemCount - 1),
                        (value, ctx) => $"Radius: {value.FormatInt("m")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("FlatHealth")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 25 * itemCount,
                        (value, ctx) => $"Health Increase: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Pearl")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.1f * itemCount,
                        (value, ctx) => $"Health Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ShinyPearl")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.1f * itemCount,
                        (value, ctx) => $"Stat Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("BonusGoldPackOnKill")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => Run.instance.GetDifficultyScaledCost(25),
                        (value, ctx) => $"per Drop: {value.FormatInt("$")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.04f * itemCount,
                        (value, ctx) => $"Drop Chance: {value.FormatPercentage()}"
                        // StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("LunarPrimaryReplacement")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 12f * itemCount,
                        (value, ctx) => $"Max Charges: {value.FormatInt()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 2f * itemCount,
                        (value, ctx) => $"Recharge Delay: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("LaserTurbine")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Pierce Damage: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 10f * itemCount,
                        (value, ctx) => $"Explosion Damage: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"On Return Damage: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("NovaOnLowHealth")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 30f / itemCount,
                        (value, ctx) => $"Recharge Delay: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("ArmorPlate")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 5,
                        (value, ctx) => $"Reduced damage: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Squid")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Attack Speed: {value.FormatPercentage(0)}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("DeathMark")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.5f,
                        (value, ctx) => $"Increased Damage: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Plant")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3 + 1.5f * (itemCount - 1),
                        (value, ctx) => $"Radius: {value.FormatInt("m", 1)}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("FocusConvergence")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 90f / (1f + 0.3f * Mathf.Min(itemCount, 3f)),
                        (value, ctx) => $"Minimum Charge Time: {value.FormatInt("s")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 1 / (2 * Mathf.Min(itemCount, 3f)),
                        (value, ctx) => $"Zone Size: {value.FormatPercentage(2)}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("DeathMark")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 7f * itemCount,
                        (value, ctx) => $"Debuff Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Plant")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 5f * itemCount,
                        (value, ctx) => $"Healing Radius: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Squid")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Attack Speed: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("CaptainDefenseMatrix")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Projectile Count: {value.FormatInt(" projectile(s)")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("CutHp")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f / (itemCount + 1),
                        (value, ctx) => $"Health Reduction: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Phasing")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 30 * Mathf.Pow(0.5f, itemCount - 1),
                        (value, ctx) => $"Cooldown: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("FallBoots")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 10f * Mathf.Pow(0.5f, itemCount - 1),
                        (value, ctx) => $"Recharge Time: {value.FormatInt("s", 2)}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("JumpBoost")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 10f * itemCount,
                        (value, ctx) => $"Boost Length: {value.FormatInt("m")}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("LunarDagger")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => Mathf.Pow(2f, itemCount),
                        (value, ctx) => $"Base Damage Increase: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 1f / Mathf.Pow(2f, itemCount),
                        (value, ctx) => $"Max Health Reduction: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("Incubator")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => (7f + 1f * itemCount) / 100f,
                        (value, ctx) => $"Summon Chance: {value.FormatPercentage()}"
                        // StatModifiers.Luck
                    ),
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Base Health: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("SiphonOnLowHealth")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Additional Enemies: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("FireballsOnHit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3 * itemCount,
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.10f,
                        (value, ctx) => $"Proc Chance: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("BleedOnHitAndExplode")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 4 * itemCount,
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.15f * itemCount,
                        (value, ctx) => $"Explosion Damage Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("MonstersOnShrineUse")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.4f * itemCount,
                        (value, ctx) => $"Enemy Difficulty Increase: {value.FormatPercentage()}"
                    ),
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("RandomDamageZone")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 16f * Mathf.Pow(1.5f, itemCount - 1),
                        (value, ctx) => $"Radius Increase: {value.FormatInt("m")}"
                    ),
                }
            };
            ItemDefs[ItemCatalog.FindItemIndex("LunarBadLuck")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Cooldown Reduction: {value.FormatInt("s")}"
                    ),
                }
            };
            // Charged Perforator
            ItemDefs[ItemCatalog.FindItemIndex("LightningStrikeOnHit")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 5f * itemCount,
                        (value, ctx) => $"Damage: {value.FormatPercentage()}"
                    ),
                }
            };
            // Empathy Cores
            ItemDefs[ItemCatalog.FindItemIndex("RoboBallBuddy")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f * itemCount,
                        (value, ctx) => $"Damage per Ally: {value.FormatPercentage()}"
                    ),
                }
            };
            // Planula
            ItemDefs[ItemCatalog.FindItemIndex("ParentEgg")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 15 * itemCount,
                        (value, ctx) => $"Heal Amount: {value.FormatInt(" HP")}"
                    ),
                }
            };
            // Essence of Heresy
            ItemDefs[ItemCatalog.FindItemIndex("LunarSpecialReplacement")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 10 * itemCount,
                        (value, ctx) => $"Effect Duration: {value.FormatInt("s")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 8 * itemCount,
                        (value, ctx) => $"Cooldown: {value.FormatInt("s")}"
                    ),
                }
            };
            // Hooks of Heresy
            ItemDefs[ItemCatalog.FindItemIndex("LunarSecondaryReplacement")] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3 * itemCount,
                        (value, ctx) => $"Root Duration: {value.FormatInt("s")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 5 * itemCount,
                        (value, ctx) => $"Cooldown: {value.FormatInt("s")}"
                    ),
                }
            };
        }
    }
}