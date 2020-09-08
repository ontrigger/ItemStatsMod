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
            ItemDefs[ItemIndex.Bear] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f - 1f / (0.15f * itemCount + 1f),
                        (value, ctx) => $"Block Chance: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Hoof] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.14f,
                        (value, ctx) => $"Movement Speed Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Syringe] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.15f,
                        (value, ctx) => $"Attack Speed Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Mushroom] = new ItemStatDef
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
            ItemDefs[ItemIndex.CritGlasses] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.1f,
                        (value, ctx) => $"Additional Crit Chance: {value.FormatPercentage(maxValue: 1f)}"
                    )
                }
            };
            ItemDefs[ItemIndex.Feather] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Total Additional Jumps: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Seed] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Total Heal: {value.FormatInt("HP")}"
                    )
                }
            };
            ItemDefs[ItemIndex.GhostOnKill] = new ItemStatDef
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
            ItemDefs[ItemIndex.Knurl] = new ItemStatDef
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
            ItemDefs[ItemIndex.Clover] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Additional Rerolls: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Medkit] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) =>
                            0.05f * itemCount * (ctx.Master != null ? ctx.Master.GetBody().maxHealth : 1),
                        (value, ctx) =>
                        {
                            var statValue = ctx.Master != null
                                ? $"{value.FormatInt("HP")}"
                                : $"{value.FormatPercentage()}";
                            return "Health Healed: " + statValue;
                        })
                }
            };
            ItemDefs[ItemIndex.Crowbar] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f + 0.5f * itemCount,
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Tooth] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.02f * itemCount,
                        (value, ctx) => $"Heal Amount: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Talisman] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2f + itemCount * 2f,
                        (value, ctx) => $"Cooldown Reduction: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.Bandolier] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f - 1f / Mathf.Pow(itemCount + 1, 0.33f),
                        (value, ctx) => $"Drop Chance: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.IceRing] = new ItemStatDef
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
            ItemDefs[ItemIndex.FireRing] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Fire Tornado Damage: {value.FormatPercentage()}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 0.08f,
                        (value, ctx) => $"Proc Chance: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.WarCryOnMultiKill] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2f + 4f * itemCount,
                        (value, ctx) => $"Frenzy Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.SprintOutOfCombat] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.3f,
                        (value, ctx) => $"Speed Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.StunChanceOnHit] = new ItemStatDef
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
            ItemDefs[ItemIndex.WarCryOnCombat] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2f + 4f * itemCount,
                        (value, ctx) => $"Frenzy Duration: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.SecondarySkillMagazine] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Bonus Stock: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.UtilitySkillMagazine] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 2f,
                        (value, ctx) => $"Bonus Charges: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.AutoCastEquipment] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.5f * Mathf.Pow(0.85f, itemCount - 1),
                        (value, ctx) => $"Cooldown Decrease: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.KillEliteFrenzy] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 4f,
                        (value, ctx) => $"Frenzy Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.BossDamageBonus] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.2f + 0.2f * (itemCount - 1),
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.ExplodeOnDeath] = new ItemStatDef
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
            ItemDefs[ItemIndex.HealWhileSafe] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Bonus Health Regen: {value.FormatInt("HP/s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.IgniteOnKill] = new ItemStatDef
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
            ItemDefs[ItemIndex.WardOnLevel] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 8f + 8f * itemCount,
                        (value, ctx) => $"Radius Increase: {value.FormatInt("m")}"
                    )
                }
            };
            ItemDefs[ItemIndex.NovaOnHeal] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Soul Energy: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.HealOnCrit] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 4f + itemCount * 4f,
                        (value, ctx) => $"Health per Crit: {value.FormatInt("HP")}"
                    )
                }
            };
            ItemDefs[ItemIndex.BleedOnHit] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.15f * itemCount,
                        (value, ctx) => $"Bleed Chance Increase: {value.FormatPercentage(maxValue: 1f)}"
                        // StatModifiers.Luck
                    )
                }
            };
            ItemDefs[ItemIndex.SlowOnHit] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2 * itemCount,
                        (value, ctx) => $"Slow Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.EquipmentMagazine] = new ItemStatDef
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
            ItemDefs[ItemIndex.GoldOnHit] = new ItemStatDef
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
            ItemDefs[ItemIndex.IncreaseHealing] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Healing Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.PersonalShield] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.08f * itemCount,
                        (value, ctx) => $"Shield Health Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.ChainLightning] = new ItemStatDef
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
            ItemDefs[ItemIndex.TreasureCache] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 80f / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                        (value, ctx) => $"Common Chance: {value.FormatPercentage(maxValue: 1f)}"
                        // StatModifiers.TreasureCache
                    ),
                    new ItemStat(
                        (itemCount, ctx) =>
                            20f * itemCount / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                        (value, ctx) => $"Uncommon Chance: {value.FormatPercentage(maxValue: 1f)}"
                        // StatModifiers.TreasureCache
                    ),
                    new ItemStat(
                        (itemCount, ctx) =>
                            Mathf.Pow(itemCount, 2f) / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                        (value, ctx) => $"Rare Chance: {value.FormatPercentage(maxValue: 1f)}"
                        // StatModifiers.TreasureCache
                    )
                }
            };
            ItemDefs[ItemIndex.BounceNearby] = new ItemStatDef
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
            ItemDefs[ItemIndex.SprintBonus] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.1f + 0.2f * itemCount,
                        (value, ctx) => $"Speed Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.SprintArmor] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 30f * itemCount,
                        (value, ctx) => $"Sprint Bonus Armor: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.ShockNearby] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 2f * itemCount,
                        (value, ctx) => $"Total Bounces: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.BeetleGland] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Total Guards: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.ShieldOnly] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.5f + (itemCount - 1) * 0.25f,
                        (value, ctx) => $"Max Health Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.StickyBomb] = new ItemStatDef
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
            ItemDefs[ItemIndex.RepeatHeal] = new ItemStatDef
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
            ItemDefs[ItemIndex.HeadHunter] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f + 5f * itemCount,
                        (value, ctx) => $"Empowerment Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.ExtraLife] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Extra Lives: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.AlienHead] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1 - Mathf.Pow(0.75f, itemCount),
                        (value, ctx) => $"Cooldown Reduction: {value.FormatPercentage(2)}"
                    )
                }
            };
            ItemDefs[ItemIndex.Firework] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 4 + itemCount * 4,
                        (value, ctx) => $"Firework Count: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Missile] = new ItemStatDef
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
            ItemDefs[ItemIndex.Infusion] = new ItemStatDef
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
            ItemDefs[ItemIndex.AttackSpeedOnCrit] = new ItemStatDef
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
            ItemDefs[ItemIndex.Icicle] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 6f * itemCount,
                        (value, ctx) => $"Radius: {value.FormatInt("m")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => 6 + (itemCount - 1) * 3,
                        (value, ctx) => $"Max Possible Icicles: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Behemoth] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1.5f + 2.5f * itemCount,
                        (value, ctx) => $"Explosion Radius: {value.FormatInt("m", 1)}"
                    )
                }
            };
            ItemDefs[ItemIndex.BarrierOnKill] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 15f * itemCount,
                        (value, ctx) => $"Barrier Health: {value.FormatInt("HP")}"
                    )
                }
            };
            ItemDefs[ItemIndex.BarrierOnOverHeal] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.5f * itemCount,
                        (value, ctx) => $"Barrier From Overheal: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.ExecuteLowHealthElite] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1 - 1 / (1 + 0.13f * itemCount),
                        (value, ctx) => $"Kill Health Threshold: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.EnergizedOnEquipmentUse] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 8f + 4f * (itemCount - 1),
                        (value, ctx) => $"Attack Speed Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.TitanGoldDuringTP] = new ItemStatDef
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
            ItemDefs[ItemIndex.SprintWisp] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Damage Boost: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Dagger] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1.5f * itemCount,
                        (value, ctx) => $"Dagger Damage: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.LunarUtilityReplacement] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Skill Duration: {value.FormatInt("s")}"
                    ),
                    new ItemStat(
                        (itemCount, ctx) => Mathf.Min(1f, 0.25f * itemCount),
                        (value, ctx) => $"Health Healed: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.NearbyDamageBonus] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.15f * itemCount,
                        (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.TPHealingNova] = new ItemStatDef
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
            ItemDefs[ItemIndex.ArmorReductionOnHit] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 8f * itemCount,
                        (value, ctx) => $"Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.Thorns] = new ItemStatDef
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
            ItemDefs[ItemIndex.RegenOnKill] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3f * itemCount,
                        (value, ctx) => $"Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.Pearl] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.1f * itemCount,
                        (value, ctx) => $"Health Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.ShinyPearl] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 0.1f * itemCount,
                        (value, ctx) => $"Stat Increase: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.BonusGoldPackOnKill] = new ItemStatDef
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
            ItemDefs[ItemIndex.LunarPrimaryReplacement] = new ItemStatDef
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
            ItemDefs[ItemIndex.LaserTurbine] = new ItemStatDef
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
            ItemDefs[ItemIndex.NovaOnLowHealth] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 30f / itemCount,
                        (value, ctx) => $"Recharge Delay: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.ArmorPlate] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 5,
                        (value, ctx) => $"Reduced damage: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Squid] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Attack Speed: {value.FormatPercentage(0)}"
                    )
                }
            };
            ItemDefs[ItemIndex.DeathMark] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount * 0.5f,
                        (value, ctx) => $"Increased Damage: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Plant] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 3 + 1.5f * (itemCount - 1),
                        (value, ctx) => $"Radius: {value.FormatInt("m", 1)}"
                    )
                }
            };
            ItemDefs[ItemIndex.FocusConvergence] = new ItemStatDef
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
            ItemDefs[ItemIndex.DeathMark] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 7f * itemCount,
                        (value, ctx) => $"Debuff Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.Plant] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 5f * itemCount,
                        (value, ctx) => $"Healing Radius: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.Squid] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Attack Speed: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.CaptainDefenseMatrix] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Projectile Count: {value.FormatInt(" projectile(s)")}"
                    )
                }
            };
            ItemDefs[ItemIndex.CutHp] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1f / (itemCount + 1),
                        (value, ctx) => $"Health Reduction: {value.FormatPercentage()}"
                    )
                }
            };
            ItemDefs[ItemIndex.Phasing] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 1.5f + itemCount * 1.5f,
                        (value, ctx) => $"Cloak Duration: {value.FormatInt("s")}"
                    )
                }
            };
            ItemDefs[ItemIndex.FallBoots] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 10f * Mathf.Pow(0.5f, itemCount - 1),
                        (value, ctx) => $"Recharge Time: {value.FormatInt("s", 2)}"
                    )
                }
            };
            ItemDefs[ItemIndex.JumpBoost] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 10f * itemCount,
                        (value, ctx) => $"Boost Length: {value.FormatInt("m")}"
                    )
                }
            };
            ItemDefs[ItemIndex.LunarDagger] = new ItemStatDef
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
            ItemDefs[ItemIndex.Incubator] = new ItemStatDef
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
            ItemDefs[ItemIndex.SiphonOnLowHealth] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Additional Enemies: {value.FormatInt()}"
                    )
                }
            };
            ItemDefs[ItemIndex.FireballsOnHit] = new ItemStatDef
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
                        // StatModifiers.Luck
                    ),
                }
            };
            ItemDefs[ItemIndex.BleedOnHitAndExplode] = new ItemStatDef
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
            ItemDefs[ItemIndex.MonstersOnShrineUse] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Enemy Difficulty Increase: {value.FormatPercentage()}"
                    ),
                }
            };
            ItemDefs[ItemIndex.RandomDamageZone] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => 16f * Mathf.Pow(1.5f, itemCount - 1),
                        (value, ctx) => $"Radius Increase: {value.FormatInt("m")}"
                    ),
                }
            };
            ItemDefs[ItemIndex.LunarBadLuck] = new ItemStatDef
            {
                Stats = new List<ItemStat>
                {
                    new ItemStat(
                        (itemCount, ctx) => itemCount,
                        (value, ctx) => $"Cooldown Reduction: {value.FormatInt("s")}"
                    ),
                }
            };
        }
    }
}