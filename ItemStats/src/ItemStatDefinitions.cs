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

            ItemDefs = new Dictionary<ItemIndex, ItemStatDef>
            {
                [ItemIndex.Bear] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f - 1f / (0.15f * itemCount + 1f),
                            (value, ctx) => $"Block Chance: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.Hoof] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 0.14f,
                            (value, ctx) => $"Movement Speed Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.Syringe] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 0.15f,
                            (value, ctx) => $"Attack Speed Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.Mushroom] = new ItemStatDef
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
                },
                [ItemIndex.CritGlasses] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 0.1f,
                            (value, ctx) => $"Additional Crit Chance: {value.FormatPercentage(maxValue: 1f)}"
                        )
                    }
                },
                [ItemIndex.Feather] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Total Additional Jumps: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.Seed] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Total Heal: {value.FormatInt("HP")}"
                        )
                    }
                },
                [ItemIndex.GhostOnKill] = new ItemStatDef
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
                },
                [ItemIndex.Knurl] = new ItemStatDef
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
                },
                [ItemIndex.Clover] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Additional Rerolls: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.Medkit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) =>
                            {
                                return 0.05f * itemCount * (ctx.Master != null ? ctx.Master.GetBody().maxHealth : 1);
                            },
                            (value, ctx) =>
                            {
                                var statValue = ctx.Master != null
                                    ? $"{value.FormatInt("HP")}"
                                    : $"{value.FormatPercentage()}";
                                return "Health Healed: " + statValue;
                            })
                    }
                },
                [ItemIndex.Crowbar] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f + 0.5f * itemCount,
                            (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.Tooth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.02f * itemCount,
                            (value, ctx) => $"Heal Amount: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.Talisman] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2f + itemCount * 2f,
                            (value, ctx) => $"Cooldown Reduction: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.Bandolier] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f - 1f / Mathf.Pow(itemCount + 1, 0.33f),
                            (value, ctx) => $"Drop Chance: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.IceRing] = new ItemStatDef
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
                },
                [ItemIndex.FireRing] = new ItemStatDef
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
                },
                [ItemIndex.WarCryOnMultiKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2f + 4f * itemCount,
                            (value, ctx) => $"Frenzy Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.SprintOutOfCombat] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 0.3f,
                            (value, ctx) => $"Speed Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.StunChanceOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f - 1f / (0.05f * itemCount + 1f),
                            (value, ctx) => $"Stun Chance Increase: {value.FormatPercentage(maxValue: 1f)}"
                            //  StatModifiers.Luck
                        )
                    }
                },
                [ItemIndex.WarCryOnCombat] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2f + 4f * itemCount,
                            (value, ctx) => $"Frenzy Duration: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.SecondarySkillMagazine] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Bonus Stock: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.UtilitySkillMagazine] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 2f,
                            (value, ctx) => $"Bonus Charges: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.AutoCastEquipment] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.5f * Mathf.Pow(0.85f, itemCount - 1),
                            (value, ctx) => $"Cooldown Decrease: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.KillEliteFrenzy] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 4f,
                            (value, ctx) => $"Frenzy Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.BossDamageBonus] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.2f + 0.2f * (itemCount - 1),
                            (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.ExplodeOnDeath] = new ItemStatDef
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
                },
                [ItemIndex.HealWhileSafe] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3f * itemCount,
                            (value, ctx) => $"Bonus Health Regen: {value.FormatInt("HP/s")}"
                        )
                    }
                },
                [ItemIndex.IgniteOnKill] = new ItemStatDef
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
                },
                [ItemIndex.WardOnLevel] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 8f + 8f * itemCount,
                            (value, ctx) => $"Radius Increase: {value.FormatInt("m")}"
                        )
                    }
                },
                [ItemIndex.NovaOnHeal] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Soul Energy: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.HealOnCrit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 4f + itemCount * 4f,
                            (value, ctx) => $"Health per Crit: {value.FormatInt("HP")}"
                        )
                    }
                },
                [ItemIndex.BleedOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.15f * itemCount,
                            (value, ctx) => $"Bleed Chance Increase: {value.FormatPercentage(maxValue: 1f)}"
                            // StatModifiers.Luck
                        )
                    }
                },
                [ItemIndex.SlowOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2 * itemCount,
                            (value, ctx) => $"Slow Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.EquipmentMagazine] = new ItemStatDef
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
                },
                [ItemIndex.GoldOnHit] = new ItemStatDef
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
                },
                [ItemIndex.IncreaseHealing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Healing Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.PersonalShield] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.08f * itemCount,
                            (value, ctx) => $"Shield Health Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.ChainLightning] = new ItemStatDef
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
                },
                [ItemIndex.TreasureCache] = new ItemStatDef
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
                },
                [ItemIndex.BounceNearby] = new ItemStatDef
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
                },
                [ItemIndex.SprintBonus] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.1f + 0.2f * itemCount,
                            (value, ctx) => $"Speed Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.SprintArmor] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 30f * itemCount,
                            (value, ctx) => $"Sprint Bonus Armor: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.ShockNearby] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2f * itemCount,
                            (value, ctx) => $"Total Bounces: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.BeetleGland] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Total Guards: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.ShieldOnly] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.5f + (itemCount - 1) * 0.25f,
                            (value, ctx) => $"Max Health Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.StickyBomb] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.05f * itemCount,
                            (value, ctx) => $"Proc Chance Increase: {value.FormatPercentage(maxValue: 1f)}"
                            // StatModifiers.Luck
                        )
                    }
                },
                [ItemIndex.RepeatHeal] = new ItemStatDef
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
                },
                [ItemIndex.HeadHunter] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3f + 5f * itemCount,
                            (value, ctx) => $"Empowerment Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.ExtraLife] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Extra Lives: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.AlienHead] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1 - Mathf.Pow(0.75f, itemCount),
                            (value, ctx) => $"Cooldown Reduction: {value.FormatPercentage(2)}"
                        )
                    }
                },
                [ItemIndex.Firework] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 4 + itemCount * 4,
                            (value, ctx) => $"Firework Count: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.Missile] = new ItemStatDef
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
                },
                [ItemIndex.Infusion] = new ItemStatDef
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
                },
                [ItemIndex.AttackSpeedOnCrit] = new ItemStatDef
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
                },
                [ItemIndex.Icicle] = new ItemStatDef
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
                },
                [ItemIndex.Behemoth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1.5f + 2.5f * itemCount,
                            (value, ctx) => $"Explosion Radius: {value.FormatInt("m", 1)}"
                        )
                    }
                },
                [ItemIndex.BarrierOnKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 15f * itemCount,
                            (value, ctx) => $"Barrier Health: {value.FormatInt("HP")}"
                        )
                    }
                },
                [ItemIndex.BarrierOnOverHeal] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.5f * itemCount,
                            (value, ctx) => $"Barrier From Overheal: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.ExecuteLowHealthElite] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1 - 1 / (1 + 0.13f * itemCount),
                            (value, ctx) => $"Kill Health Threshold: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.EnergizedOnEquipmentUse] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 8f + 4f * (itemCount - 1),
                            (value, ctx) => $"Attack Speed Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.TitanGoldDuringTP] = new ItemStatDef
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
                },
                [ItemIndex.SprintWisp] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3f * itemCount,
                            (value, ctx) => $"Damage Boost: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.Dagger] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1.5f * itemCount,
                            (value, ctx) => $"Dagger Damage: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.LunarUtilityReplacement] = new ItemStatDef
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
                },
                [ItemIndex.NearbyDamageBonus] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.15f * itemCount,
                            (value, ctx) => $"Damage Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.TPHealingNova] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Max Occurrences: {value.FormatInt()}"
                            // StatModifiers.TpHealingNova
                        )
                    }
                },
                [ItemIndex.ArmorReductionOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 8f * itemCount,
                            (value, ctx) => $"Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.Thorns] = new ItemStatDef
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
                },
                [ItemIndex.RegenOnKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3f * itemCount,
                            (value, ctx) => $"Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.Pearl] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.1f * itemCount,
                            (value, ctx) => $"Health Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.ShinyPearl] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.1f * itemCount,
                            (value, ctx) => $"Stat Increase: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.BonusGoldPackOnKill] = new ItemStatDef
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
                },
                [ItemIndex.LunarPrimaryReplacement] = new ItemStatDef
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
                },
                [ItemIndex.LaserTurbine] = new ItemStatDef
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
                },
                [ItemIndex.NovaOnLowHealth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 30f / itemCount,
                            (value, ctx) => $"Recharge Delay: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.ArmorPlate] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 5,
                            (value, ctx) => $"Reduced damage: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.Squid] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Attack Speed: {value.FormatPercentage(0)}"
                        )
                    }
                },
                [ItemIndex.DeathMark] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 0.5f,
                            (value, ctx) => $"Increased Damage: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.Plant] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3 + 1.5f * (itemCount - 1),
                            (value, ctx) => $"Radius: {value.FormatInt("m", 1)}"
                        )
                    }
                },
                [ItemIndex.FocusConvergence] = new ItemStatDef
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
                },
                [ItemIndex.DeathMark] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 7f * itemCount,
                            (value, ctx) => $"Debuff Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.Plant] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 5f * itemCount,
                            (value, ctx) => $"Healing Radius: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.Squid] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Attack Speed: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.CaptainDefenseMatrix] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Projectile Count: {value.FormatInt(" projectile(s)")}"
                        )
                    }
                },
                [ItemIndex.CutHp] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f / (itemCount + 1),
                            (value, ctx) => $"Health Reduction: {value.FormatPercentage()}"
                        )
                    }
                },
                [ItemIndex.Phasing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1.5f + itemCount * 1.5f,
                            (value, ctx) => $"Cloak Duration: {value.FormatInt("s")}"
                        )
                    }
                },
                [ItemIndex.FallBoots] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 10f * Mathf.Pow(0.5f, itemCount - 1),
                            (value, ctx) => $"Recharge Time: {value.FormatInt("s", 2)}"
                        )
                    }
                },
                [ItemIndex.JumpBoost] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 10f * itemCount,
                            (value, ctx) => $"Boost Length: {value.FormatInt("m")}"
                        )
                    }
                },
                [ItemIndex.LunarDagger] = new ItemStatDef
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
                },
                [ItemIndex.Incubator] = new ItemStatDef
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
                },
                [ItemIndex.SiphonOnLowHealth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Additional Enemies: {value.FormatInt()}"
                        )
                    }
                },
                [ItemIndex.FireballsOnHit] = new ItemStatDef
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
                },
                [ItemIndex.BleedOnHitAndExplode] = new ItemStatDef
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
                },
                [ItemIndex.MonstersOnShrineUse] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Enemy Difficulty Increase: {value.FormatPercentage()}"
                        ),
                    }
                },
                [ItemIndex.RandomDamageZone] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 16f * Mathf.Pow(1.5f, itemCount - 1),
                            (value, ctx) => $"Radius Increase: {value.FormatInt("m")}"
                        ),
                    }
                },
                [ItemIndex.LunarBadLuck] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            (value, ctx) => $"Cooldown Reduction: {value.FormatInt("s")}"
                        ),
                    }
                },
            };
        }
    }
}