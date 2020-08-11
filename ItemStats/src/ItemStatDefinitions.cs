using System;
using System.Collections.Generic;
using EntityStates;
using ItemStats.Stat;
using ItemStats.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStats
{
    public partial class ItemStatProvider
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
                            count => 1f - 1f / (0.15f * count + 1f),
                            "Block Chance"
                        )
                    }
                },
                [ItemIndex.Hoof] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 0.14f,
                            "Movement Speed Increase"
                        )
                    }
                },
                [ItemIndex.Syringe] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            count => count * 0.15f,
                            "Attack Speed Increase"
                        )
                    }
                },
                [ItemIndex.Mushroom] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            count => 0.0225f + 0.0225f * count,
                            "Healing Per Second",
                            // TODO: use a decorator instead of additional param for the formatter
                            new PercentageFormatter(maxValue: 1f)
                        ),
                        new ItemStat(
                            itemCount => 1.5f + 1.5f * itemCount,
                            "Area Increase",
                            new IntFormatter("m")
                        )
                    }
                },
                [ItemIndex.CritGlasses] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 0.1f,
                            "Additional Crit Chance",
                            new PercentageFormatter(maxValue: 1f)
                        )
                    }
                },
                [ItemIndex.Feather] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Total Additional  Jumps",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.Seed] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Total Heal Hp",
                            new IntFormatter("HP")
                        )
                    }
                },
                [ItemIndex.GhostOnKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 30f,
                            "Ghost Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.Knurl] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 40f,
                            "Bonus Health",
                            new IntFormatter("HP")
                        ),
                        new ItemStat(
                            itemCount => itemCount * 1.6f,
                            "Additional Regeneration",
                            new IntFormatter("HP/s")
                        )
                    }
                },
                [ItemIndex.Clover] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Additional Rerolls",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.Medkit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.05f * itemCount,
                            "Health Healed"
                        )
                    }
                },
                [ItemIndex.Crowbar] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 1f + 0.5f * itemCount,
                            "Damage Increase"
                        )
                    }
                },
                [ItemIndex.Tooth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.02f * itemCount,
                            "Heal Amount"
                        )
                    }
                },
                [ItemIndex.Talisman] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 2f + itemCount * 2f,
                            "Cooldown Reduction",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.Bandolier] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            formula: itemCount => 1f - 1f / Mathf.Pow(itemCount + 1, 0.33f),
                            statText: "Drop Chance",
                            modifiers: Modifiers.Clover
                        )
                    }
                },
                [ItemIndex.IceRing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 2.5f * itemCount,
                            "Ice Blast Damage"
                        ),
                        new ItemStat(
                            formula: itemCount => 3f * itemCount,
                            statText: "Ice Debuff Duration",
                            formatter: new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.FireRing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3f * itemCount,
                            "Fire Tornado Damage"
                        ),
                        new ItemStat(
                            formula: itemCount => 0.08f,
                            statText: "Proc Chance",
                            modifiers: Modifiers.Clover
                        )
                    }
                },
                [ItemIndex.WarCryOnMultiKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 2f + 4f * itemCount,
                            "Frenzy Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.SprintOutOfCombat] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 0.3f,
                            "Speed Increase"
                        )
                    }
                },
                [ItemIndex.StunChanceOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            formula: itemCount => 1f - 1f / (0.05f * itemCount + 1f),
                            statText: "Stun Chance Increase",
                            formatter: new PercentageFormatter(maxValue: 1f),
                            modifiers: Modifiers.Clover
                        )
                    }
                },
                [ItemIndex.WarCryOnCombat] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 2f + 4f * itemCount,
                            "Frenzy Duration",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.SecondarySkillMagazine] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Bonus Stock",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.UtilitySkillMagazine] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 2f,
                            "Bonus Charges",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.AutoCastEquipment] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.5f * Mathf.Pow(0.85f, itemCount - 1),
                            "Cooldown Decrease",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.KillEliteFrenzy] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 4f,
                            "Frenzy Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.BossDamageBonus] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.2f + 0.2f * (itemCount - 1),
                            "Damage Increase"
                        )
                    }
                },
                [ItemIndex.ExplodeOnDeath] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 12f + 2.4f * (itemCount - 1f),
                            "Radius Increase",
                            new IntFormatter("m")
                        ),
                        new ItemStat(
                            itemCount => 3.5f * (1f + (itemCount - 1) * 0.8f),
                            "Damage Increase"
                        )
                    }
                },
                [ItemIndex.HealWhileSafe] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3f * itemCount,
                            "Bonus Health Regen",
                            new IntFormatter("hp/s")
                        )
                    }
                },
                [ItemIndex.IgniteOnKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 8f + 4f * itemCount,
                            "Radius Increase",
                            new IntFormatter("m")
                        ),
                        new ItemStat(
                            itemCount => 1.5f + 1.5f * itemCount,
                            "Duration Increase"
                        )
                    }
                },
                [ItemIndex.WardOnLevel] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 8f + 8f * itemCount,
                            "Radius Increase",
                            new IntFormatter("m")
                        )
                    }
                },
                [ItemIndex.NovaOnHeal] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Soul Energy"
                        )
                    }
                },
                [ItemIndex.HealOnCrit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 4f + itemCount * 4f,
                            "Health per Crit",
                            new IntFormatter("HP")
                        )
                    }
                },
                [ItemIndex.BleedOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            formula: itemCount => 0.15f * itemCount,
                            statText: "Bleed Chance Increase",
                            formatter: new PercentageFormatter(maxValue: 1f),
                            modifiers: Modifiers.Clover
                        )
                    }
                },
                [ItemIndex.SlowOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 2 * itemCount,
                            "Slow Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.EquipmentMagazine] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Bonus Charges",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            itemCount => 1 - Mathf.Pow(0.85f, itemCount),
                            "Cooldown Decrease"
                        )
                    }
                },
                [ItemIndex.GoldOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            //TODO: make run a modifier
                            itemCount => itemCount * 2f * Run.instance.difficultyCoefficient,
                            "Gold per Hit(*)",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            formula: itemCount => 0.3f,
                            statText: "Proc Chance",
                            modifiers: Modifiers.Clover
                        )
                    }
                },
                [ItemIndex.IncreaseHealing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Healing Increase"
                        )
                    }
                },
                [ItemIndex.PersonalShield] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.08f * itemCount,
                            "Shield Health Increase",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.ChainLightning] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 2f,
                            "Total Bounces",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            itemCount => 20f + 2f * itemCount,
                            "Bounce Range",
                            new IntFormatter("m")
                        ),
                        new ItemStat(
                            formula: itemCount => 0.25f,
                            statText: "Proc Chance",
                            formatter: new PercentageFormatter(),
                            modifiers: Modifiers.Clover
                        )
                    }
                },
                [ItemIndex.TreasureCache] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            formula: itemCount => 80f / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                            statText: "Common Chance",
                            formatter: new PercentageFormatter(maxValue: 1f),
                            modifiers: Modifiers.TreasureCache
                        ),
                        new ItemStat(
                            formula: itemCount =>
                                20f * itemCount / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                            statText: "Uncommon Chance",
                            formatter: new PercentageFormatter(maxValue: 1f),
                            modifiers: Modifiers.TreasureCache
                        ),
                        new ItemStat(
                            formula: itemCount =>
                                Mathf.Pow(itemCount, 2f) / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                            statText: "Rare Chance",
                            formatter: new PercentageFormatter(maxValue: 1f),
                            modifiers: Modifiers.TreasureCache
                        )
                    }
                },
                [ItemIndex.BounceNearby] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            formula: itemCount => 1f - 100f / (100f + 20f * itemCount),
                            statText: "Hook Chance",
                            modifiers: Modifiers.Clover
                        ),
                        new ItemStat(
                            itemCount => 5f + itemCount * 5f,
                            "Max Enemies Hooked",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.SprintBonus] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.1f + 0.2f * itemCount,
                            "Speed Increase"
                        )
                    }
                },
                [ItemIndex.SprintArmor] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 30f * itemCount,
                            "Sprint Bonus Armor",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.ShockNearby] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 2f * itemCount,
                            "Total Bounces",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.BeetleGland] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Total Guards",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.ShieldOnly] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.5f + (itemCount - 1) * 0.25f,
                            "Max Health Increase"
                        )
                    }
                },
                [ItemIndex.StickyBomb] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            formula: itemCount => 0.05f * itemCount,
                            statText: "Proc Chance Increase",
                            formatter: new PercentageFormatter(maxValue: 1f),
                            modifiers: Modifiers.Clover
                        )
                    }
                },
                [ItemIndex.RepeatHeal] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        //TODO: need to get masters maxhealth to get actual heal amount
                        new ItemStat(
                            itemCount => 0.1f / itemCount,
                            "Health Fraction/s"
                        ),
                        new ItemStat(
                            itemCount => 1 + itemCount,
                            "Healing per Heal Increase"
                        )
                    }
                },
                [ItemIndex.HeadHunter] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3f + 5f * itemCount,
                            "Empowering Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.ExtraLife] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Extra Lives",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.AlienHead] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 1 - Mathf.Pow(0.75f, itemCount),
                            "Cooldown Reduction",
                            new PercentageFormatter(2)
                        )
                    }
                },
                [ItemIndex.Firework] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 4 + itemCount * 4,
                            "Firework Count",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.Missile] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3 * itemCount,
                            "Missile Total Damage",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            formula: itemCount => 0.1f,
                            statText: "Proc Chance",
                            formatter: new PercentageFormatter(),
                            modifiers: Modifiers.Clover
                        )
                    }
                },
                [ItemIndex.Infusion] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 100 * itemCount,
                            "Max Additional Health",
                            new IntFormatter("HP")
                        ),
                        new ItemStat(
                            itemCount => itemCount,
                            "HP Gained Per Kill"
                        )
                    }
                },
                [ItemIndex.JumpBoost] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 10 * itemCount,
                            "Boost Length",
                            new IntFormatter("m")
                        )
                    }
                },
                [ItemIndex.AttackSpeedOnCrit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.1f + 0.2f * itemCount,
                            "Max Attack Speed"
                        )
                    }
                },
                [ItemIndex.Icicle] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 1.5f * itemCount,
                            "Icicle Damage"
                        ),
                        new ItemStat(
                            itemCount => 6 + (itemCount - 1) * 3,
                            "Max Possible Icicles"
                        )
                    }
                },
                [ItemIndex.Behemoth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 1.5f + 2.5f * itemCount,
                            "Explosion Radius",
                            new IntFormatter("m", 1)
                        )
                    }
                },
                [ItemIndex.BarrierOnKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 15f * itemCount,
                            "Barrier Health",
                            new IntFormatter("HP")
                        )
                    }
                },
                [ItemIndex.BarrierOnOverHeal] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.5f * itemCount,
                            "Barrier From Overheal",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.ExecuteLowHealthElite] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 1 - 1 / (1 + 0.13f * itemCount),
                            "Kill Health Threshold",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.EnergizedOnEquipmentUse] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 8f + 4f * (itemCount - 1),
                            "Attack Speed Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.TitanGoldDuringTP] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Health Boost",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            itemCount => 0.5f + 0.5f * itemCount,
                            "Damage Boost",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.SprintWisp] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3f * itemCount,
                            "Damage Boost",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.Dagger] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 1.5f * itemCount,
                            "Dagger Damage",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.LunarUtilityReplacement] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3f * itemCount,
                            "Skill Duration",
                            new IntFormatter("s")
                        ),
                        new ItemStat(
                            itemCount =>
                            {
                                var maxHealth = LocalUserManager.FindLocalUser(0)?.cachedBody.maxHealth;
                                var healingPerSecond = maxHealth
                                                       * GhostUtilitySkillState.healFractionPerTick
                                                       * GhostUtilitySkillState.healFrequency;

                                return healingPerSecond;
                            },
                            "Health Healed",
                            new IntFormatter("HP/s")
                        )
                    }
                },
                [ItemIndex.NearbyDamageBonus] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.15f * itemCount,
                            "Damage Increase",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.TPHealingNova] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            formula: itemCount => itemCount,
                            statText: "Max Occurrences",
                            formatter: new IntFormatter(),
                            modifiers: Modifiers.TpHealingNova
                        )
                    }
                },
                [ItemIndex.ArmorReductionOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 8f * itemCount,
                            "Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.Thorns] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 5 + 2 * (itemCount - 1),
                            "Max Targets",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            itemCount => 25f + 10f * (itemCount - 1),
                            "Radius",
                            new IntFormatter("m")
                        )
                    }
                },
                [ItemIndex.RegenOnKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3f * itemCount,
                            "Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.Pearl] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.1f * itemCount,
                            "Health Increase",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.ShinyPearl] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 0.1f * itemCount,
                            "Stat Increase",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.BonusGoldPackOnKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => Run.instance.GetDifficultyScaledCost(25),
                            "per Drop",
                            new IntFormatter("$")
                        ),
                        new ItemStat(
                            itemCount => 0.04f * itemCount,
                            "Drop Chance",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.LunarPrimaryReplacement] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 12f * itemCount,
                            "Max Charges",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            itemCount => 2f * itemCount,
                            "Recharge Delay",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.LaserTurbine] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3f * itemCount,
                            "Pierce Damage",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            itemCount => 10f * itemCount,
                            "Explosion Damage",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            itemCount => 3f * itemCount,
                            "On Return Damage",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.LunarTrinket] = new ItemStatDef
                {
                    Stats = new List<ItemStat>()
                },
                [ItemIndex.NovaOnLowHealth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 30f / (itemCount + 1),
                            "Recharge Delay",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.ArmorPlate] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 5,
                            "Reduced damage",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.Squid] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount,
                            "Attack Speed",
                            new PercentageFormatter(0)
                        )
                    }
                },
                [ItemIndex.DeathMark] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => itemCount * 0.5f,
                            "Increased Damage",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.Plant] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 3 + 1.5f * (itemCount - 1),
                            "Radius",
                            new IntFormatter("m", 1)
                        )
                    }
                },
                [ItemIndex.FocusConvergence] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 1 + 0.3f * Math.Min(itemCount, 3),
                            "Bonus Charge Speed",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            itemCount => 1f / (2 * Math.Min(itemCount, 3)),
                            "Radius",
                            new PercentageFormatter(2)
                        )
                    }
                },
                [ItemIndex.DeathMark] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 7f * itemCount,
                            "Debuff Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.Plant] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            itemCount => 5f * itemCount,
                            "Healing Radius",
                            new IntFormatter("m")
                        )
                    }
                },
            };
        }
    }
}