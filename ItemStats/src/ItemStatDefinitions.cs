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
                            "Block Chance"
                        )
                    }
                },
                [ItemIndex.Hoof] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 0.14f,
                            "Movement Speed Increase"
                        )
                    }
                },
                [ItemIndex.Syringe] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 0.15f,
                            "Attack Speed Increase"
                        )
                    }
                },
                [ItemIndex.Mushroom] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.0225f + 0.0225f * itemCount,
                            "Healing Per Second",
                            // TODO: use a decorator instead of additional param for the formatter
                            new PercentageFormatter(maxValue: 1f)
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 1.5f + 1.5f * itemCount,
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
                            (itemCount, ctx) => itemCount * 0.1f,
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
                            (itemCount, ctx) => itemCount,
                            "Total Additional Jumps",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.Seed] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Total Heal",
                            new IntFormatter(" HP")
                        )
                    }
                },
                [ItemIndex.GhostOnKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 30f,
                            "Ghost Duration",
                            new IntFormatter("s")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.07f,
                            "Proc Chance",
                            new PercentageFormatter(),
                            Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.Knurl] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 40f,
                            "Bonus Health",
                            new IntFormatter("HP")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => itemCount * 1.6f,
                            "Additional Regeneration",
                            new IntFormatter("HP/s", 1)
                        )
                    }
                },
                [ItemIndex.Clover] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
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
                            (itemCount, ctx) => 0.05f * itemCount,
                            "Health Healed"
                        )
                    }
                },
                [ItemIndex.Crowbar] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f + 0.5f * itemCount,
                            "Damage Increase"
                        )
                    }
                },
                [ItemIndex.Tooth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.02f * itemCount,
                            "Heal Amount"
                        )
                    }
                },
                [ItemIndex.Talisman] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2f + itemCount * 2f,
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
                            (itemCount, ctx) => 1f - 1f / Mathf.Pow(itemCount + 1, 0.33f),
                            "Drop Chance",
                            modifiers: Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.IceRing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2.5f * itemCount,
                            "Ice Blast Damage"
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 3f * itemCount,
                            "Ice Debuff Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.FireRing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3f * itemCount,
                            "Fire Tornado Damage"
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.08f,
                            "Proc Chance",
                            modifiers: Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.WarCryOnMultiKill] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2f + 4f * itemCount,
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
                            (itemCount, ctx) => itemCount * 0.3f,
                            "Speed Increase"
                        )
                    }
                },
                [ItemIndex.StunChanceOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f - 1f / (0.05f * itemCount + 1f),
                            "Stun Chance Increase",
                            new PercentageFormatter(maxValue: 1f),
                            Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.WarCryOnCombat] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2f + 4f * itemCount,
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
                            (itemCount, ctx) => itemCount,
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
                            (itemCount, ctx) => itemCount * 2f,
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
                            (itemCount, ctx) => 0.5f * Mathf.Pow(0.85f, itemCount - 1),
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
                            (itemCount, ctx) => itemCount * 4f,
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
                            (itemCount, ctx) => 0.2f + 0.2f * (itemCount - 1),
                            "Damage Increase"
                        )
                    }
                },
                [ItemIndex.ExplodeOnDeath] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 12f + 2.4f * (itemCount - 1f),
                            "Radius Increase",
                            new IntFormatter("m")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 3.5f * (1f + (itemCount - 1) * 0.8f),
                            "Damage Increase"
                        )
                    }
                },
                [ItemIndex.HealWhileSafe] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3f * itemCount,
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
                            (itemCount, ctx) => 8f + 4f * itemCount,
                            "Radius Increase",
                            new IntFormatter("m")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 1.5f + 1.5f * itemCount,
                            "Duration Increase"
                        )
                    }
                },
                [ItemIndex.WardOnLevel] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 8f + 8f * itemCount,
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
                            (itemCount, ctx) => itemCount,
                            "Soul Energy"
                        )
                    }
                },
                [ItemIndex.HealOnCrit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 4f + itemCount * 4f,
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
                            (itemCount, ctx) => 0.15f * itemCount,
                            "Bleed Chance Increase",
                            new PercentageFormatter(maxValue: 1f),
                            Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.SlowOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 2 * itemCount,
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
                            (itemCount, ctx) => itemCount,
                            "Bonus Charges",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 1 - Mathf.Pow(0.85f, itemCount),
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
                            (itemCount, ctx) => itemCount * 2f * Run.instance.difficultyCoefficient,
                            "Gold per Hit(*)",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.3f,
                            "Proc Chance",
                            modifiers: Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.IncreaseHealing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Healing Increase"
                        )
                    }
                },
                [ItemIndex.PersonalShield] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.08f * itemCount,
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
                            (itemCount, ctx) => itemCount * 2f,
                            "Total Bounces",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 20f + 2f * itemCount,
                            "Bounce Range",
                            new IntFormatter("m")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.25f,
                            "Proc Chance",
                            new PercentageFormatter(),
                            Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.TreasureCache] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 80f / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                            "Common Chance",
                            new PercentageFormatter(maxValue: 1f),
                            Modifiers.TreasureCache
                        ),
                        new ItemStat(
                            (itemCount, ctx) =>
                                20f * itemCount / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                            "Uncommon Chance",
                            new PercentageFormatter(maxValue: 1f),
                            Modifiers.TreasureCache
                        ),
                        new ItemStat(
                            (itemCount, ctx) =>
                                Mathf.Pow(itemCount, 2f) / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f)),
                            "Rare Chance",
                            new PercentageFormatter(maxValue: 1f),
                            Modifiers.TreasureCache
                        )
                    }
                },
                [ItemIndex.BounceNearby] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f - 100f / (100f + 20f * itemCount),
                            "Hook Chance",
                            modifiers: Modifiers.Luck
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 5f + itemCount * 5f,
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
                            (itemCount, ctx) => 0.1f + 0.2f * itemCount,
                            "Speed Increase"
                        )
                    }
                },
                [ItemIndex.SprintArmor] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 30f * itemCount,
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
                            (itemCount, ctx) => 2f * itemCount,
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
                            (itemCount, ctx) => itemCount,
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
                            (itemCount, ctx) => 0.5f + (itemCount - 1) * 0.25f,
                            "Max Health Increase"
                        )
                    }
                },
                [ItemIndex.StickyBomb] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.05f * itemCount,
                            "Proc Chance Increase",
                            new PercentageFormatter(maxValue: 1f),
                            Modifiers.Luck
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
                            "Health Fraction/s"
                        ),
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Healing per Heal Increase"
                        )
                    }
                },
                [ItemIndex.HeadHunter] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3f + 5f * itemCount,
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
                            (itemCount, ctx) => itemCount,
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
                            (itemCount, ctx) => 1 - Mathf.Pow(0.75f, itemCount),
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
                            (itemCount, ctx) => 4 + itemCount * 4,
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
                            (itemCount, ctx) => 3 * itemCount,
                            "Missile Total Damage",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.1f,
                            "Proc Chance",
                            new PercentageFormatter(),
                            Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.Infusion] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 100 * itemCount,
                            "Max Additional Health",
                            new IntFormatter("HP")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Health Gained Per Kill",
                            new IntFormatter("HP")
                        )
                    }
                },
                [ItemIndex.AttackSpeedOnCrit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.12f + 0.24f * itemCount,
                            "Max Attack Speed"
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.05f,
                            "Crit Chance Bonus"
                        )
                    }
                },
                [ItemIndex.Icicle] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 6f * itemCount,
                            "Radius",
                            new IntFormatter("m")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 6 + (itemCount - 1) * 3,
                            "Max Possible Icicles"
                        )
                    }
                },
                [ItemIndex.Behemoth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1.5f + 2.5f * itemCount,
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
                            (itemCount, ctx) => 15f * itemCount,
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
                            (itemCount, ctx) => 0.5f * itemCount,
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
                            (itemCount, ctx) => 1 - 1 / (1 + 0.13f * itemCount),
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
                            (itemCount, ctx) => 8f + 4f * (itemCount - 1),
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
                            (itemCount, ctx) => itemCount,
                            "Health Boost",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.5f + 0.5f * itemCount,
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
                            (itemCount, ctx) => 3f * itemCount,
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
                            (itemCount, ctx) => 1.5f * itemCount,
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
                            (itemCount, ctx) => 3f * itemCount,
                            "Skill Duration",
                            new IntFormatter("s")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => Mathf.Min(1f, 0.25f * itemCount),
                            "Health Healed"
                        )
                    }
                },
                [ItemIndex.NearbyDamageBonus] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 0.15f * itemCount,
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
                            (itemCount, ctx) => itemCount,
                            "Max Occurrences",
                            new IntFormatter(),
                            Modifiers.TpHealingNova
                        )
                    }
                },
                [ItemIndex.ArmorReductionOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 8f * itemCount,
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
                            (itemCount, ctx) => 5 + 2 * (itemCount - 1),
                            "Max Targets",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 25f + 10f * (itemCount - 1),
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
                            (itemCount, ctx) => 3f * itemCount,
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
                            (itemCount, ctx) => 0.1f * itemCount,
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
                            (itemCount, ctx) => 0.1f * itemCount,
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
                            (itemCount, ctx) => Run.instance.GetDifficultyScaledCost(25),
                            "per Drop",
                            new IntFormatter("$")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.04f * itemCount,
                            "Drop Chance",
                            new PercentageFormatter(),
                            Modifiers.Luck
                        )
                    }
                },
                [ItemIndex.LunarPrimaryReplacement] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 12f * itemCount,
                            "Max Charges",
                            new IntFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 2f * itemCount,
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
                            (itemCount, ctx) => 3f * itemCount,
                            "Pierce Damage",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 10f * itemCount,
                            "Explosion Damage",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 3f * itemCount,
                            "On Return Damage",
                            new PercentageFormatter()
                        )
                    }
                },
                [ItemIndex.NovaOnLowHealth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 30f / itemCount,
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
                            (itemCount, ctx) => itemCount * 5,
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
                            (itemCount, ctx) => itemCount,
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
                            (itemCount, ctx) => itemCount * 0.5f,
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
                            (itemCount, ctx) => 3 + 1.5f * (itemCount - 1),
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
                            (itemCount, ctx) => 90f / (1f + 0.3f * Mathf.Min(itemCount, 3f)),
                            "Minimum Charge Time",
                            new IntFormatter("s")
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 1 / (2 * Mathf.Min(itemCount, 3f)),
                            "Zone Size",
                            new PercentageFormatter(2)
                        )
                    }
                },
                [ItemIndex.DeathMark] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 7f * itemCount,
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
                            (itemCount, ctx) => 5f * itemCount,
                            "Healing Radius",
                            new IntFormatter("m")
                        )
                    }
                },
                [ItemIndex.Squid] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Attack Speed"
                        )
                    }
                },
                [ItemIndex.CaptainDefenseMatrix] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Projectile Count",
                            new IntFormatter(" projectile(s)")
                        )
                    }
                },
                [ItemIndex.CutHp] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1f / (itemCount + 1),
                            "Health Reduction"
                        )
                    }
                },
                [ItemIndex.Phasing] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 1.5f + itemCount * 1.5f,
                            "Cloak Duration",
                            new IntFormatter("s")
                        )
                    }
                },
                [ItemIndex.FallBoots] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 10f * Mathf.Pow(0.5f, itemCount - 1),
                            "Recharge Time",
                            new IntFormatter("s", 2)
                        )
                    }
                },
                [ItemIndex.JumpBoost] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 10f * itemCount,
                            "Boost Length",
                            new IntFormatter("m")
                        )
                    }
                },
                [ItemIndex.LunarDagger] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => Mathf.Pow(2f, itemCount),
                            "Base Damage Increase"
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 1f / Mathf.Pow(2f, itemCount),
                            "Max Health Reduction"
                        )
                    }
                },
                [ItemIndex.Incubator] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => (7f + 1f * itemCount) / 100f,
                            "Summon Chance",
                            new PercentageFormatter(),
                            Modifiers.Luck
                        ),
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Base Health"
                        )
                    }
                },
                [ItemIndex.SiphonOnLowHealth] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Additional Enemies",
                            new IntFormatter()
                        )
                    }
                },
                [ItemIndex.FireballsOnHit] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 3 * itemCount,
                            "Damage Increase",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.10f,
                            "Proc Chance",
                            new PercentageFormatter(),
                            Modifiers.Luck
                        ),
                    }
                },
                [ItemIndex.BleedOnHitAndExplode] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => 4 * itemCount,
                            "Damage Increase",
                            new PercentageFormatter()
                        ),
                        new ItemStat(
                            (itemCount, ctx) => 0.15f * itemCount,
                            "Explosion Damage Increase"
                        )
                    }
                },
                [ItemIndex.MonstersOnShrineUse] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Enemy Difficulty Increase",
                            new PercentageFormatter()
                        ),
                    }
                },
                [ItemIndex.RandomDamageZone] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) =>
                            {
                                var radius = 16f;
                                for (var i = 0; i < itemCount - 1; i++)
                                {
                                    radius *= 1.5f;
                                }

                                return radius;
                            },
                            "Radius Increase",
                            new IntFormatter("m")
                        ),
                    }
                },
                [ItemIndex.LunarBadLuck] = new ItemStatDef
                {
                    Stats = new List<ItemStat>
                    {
                        new ItemStat(
                            (itemCount, ctx) => itemCount,
                            "Cooldown Reduction",
                            new IntFormatter("s")
                        ),
                    }
                },
            };
        }
    }
}