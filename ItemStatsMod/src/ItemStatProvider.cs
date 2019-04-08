using System;
using System.Collections.Generic;
using ItemStatsMod.ValueFormatters;
using RoR2;
using UnityEngine;

namespace ItemStatsMod
{
    public static class ItemStatProvider
    {
        public static string ProvideStatsForItem(ItemIndex itemIndex, int itemCount)
        {
            var itemStatList = testDefs.ContainsKey(itemIndex) ? testDefs[itemIndex] : null;

            if (itemStatList == null)
            {
                return "NOT IMPL";
            }

            var fullStatText = string.Empty;
            foreach (Test subItemStat in itemStatList)
            {
                float statValue = subItemStat.CalculateStat(itemCount);

                var statValueStr = subItemStat.Formatter.Format(statValue);

                if (itemStatList.IndexOf(subItemStat) == itemStatList.Count - 1)
                {
                    // this is the last line
                    // TextMeshPro richtext modifier that allows me to align the stack counter on the right
                    // also TODO: implement WrapIn string extension
                    fullStatText += $"<align=left>{subItemStat.StatText}: {statValueStr}<line-height=0>";
                }
                else
                {
                    fullStatText += $"{subItemStat.StatText}: {statValueStr}\n";
                }
            }

            return $"{fullStatText}\n<align=right>({itemCount} stacks)<line-height=1em>";
        }

        static ItemStatProvider()
        {
            testDefs = new Dictionary<ItemIndex, List<Test>>
            {
                [ItemIndex.Bear] = new List<Test>()
                {
                    new Test(calculateStat: (itemCount) => (1f - 1f / (0.15f * itemCount + 1f)),
                        statText: "Proc Chance"
                    ),
                },


                [ItemIndex.Hoof] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 0.14f,
                        statText: "Walk Speed Increase"
                    )
                },


                [ItemIndex.Syringe] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 0.15f,
                        statText: "Attack Speed Increase"
                    )
                },

                [ItemIndex.Mushroom] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 0.0225f + 0.0225f * itemCount,
                        statText: "Healing Increase"
                    ),
                    new Test(
                        calculateStat: (itemCount) => 1.5f + 1.5f * itemCount,
                        statText: "Area Increase",
                        formatter: new IntFormatter("m")
                    )
                },
                [ItemIndex.CritGlasses] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 0.1f,
                        statText: "Crit Chance"
                    )
                },
                [ItemIndex.Feather] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Total Jumps",
                        formatter: new IntFormatter()
                    )
                },
                [ItemIndex.Seed] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Total Heal Hp",
                        formatter: new IntFormatter("HP")
                    )
                },
                [ItemIndex.GhostOnKill] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 30f,
                        statText: "Ghost Duration",
                        formatter: new IntFormatter("s")
                    )
                },
                [ItemIndex.Knurl] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 40f,
                        statText: "Maximum Health",
                        formatter: new IntFormatter("HP")
                    ),
                    new Test(
                        calculateStat: (itemCount) => itemCount * 1.6f,
                        statText: "Regeneration",
                        formatter: new IntFormatter("HP/s")
                    ),
                },
                [ItemIndex.Clover] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Additional Rerolls",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.Medkit] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 10f,
                        statText: "Health Healed",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.Crowbar] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 1.5f + 0.3f * (itemCount - 1),
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.Tooth] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 4 * itemCount,
                        statText: "Heal Amount",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.Talisman] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 2f + itemCount * 2f,
                        statText: "Cooldown Reduction",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.Bandolier] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => (1f - 1f / Mathf.Pow(itemCount + 1, 0.33f)),
                        statText: "Drop Chance"
                    ),
                },
                [ItemIndex.IceRing] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 1.25f + 1.25f * itemCount,
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.FireRing] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 2.5f + 2.5f * itemCount,
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.WarCryOnMultiKill] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 2f + 4f * itemCount,
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.SprintOutOfCombat] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 0.3f,
                        statText: "Speed Increase"
                    ),
                },
                [ItemIndex.StunChanceOnHit] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 1f - 1f / (0.05f * itemCount + 1f),
                        statText: "Stun Chance Increase"
                    ),
                },
                [ItemIndex.WarCryOnCombat] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 2f + 4f * itemCount,
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.SecondarySkillMagazine] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Bonus Stock",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.UtilitySkillMagazine] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 2f,
                        statText: "Bonus Charges",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.AutoCastEquipment] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 1 - Mathf.Pow(0.5f, itemCount),
                        statText: "Cooldown Decrease",
                        formatter: new PercentageFormatter(0)
                    ),
                },
                [ItemIndex.KillEliteFrenzy] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 1f + itemCount * 2f,
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.BossDamageBonus] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 0.2f + 0.1f * (itemCount - 1),
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.ExplodeOnDeath] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 12f + 2.4f * (itemCount - 1f),
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                    new Test(
                        calculateStat: (itemCount) => 3.5f * (1f + (itemCount - 1) * 0.8f),
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.HealWhileSafe] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 2.5f + (itemCount - 1) * 1.5f,
                        statText: "Regeneration Increase"
                    ),
                },
                [ItemIndex.IgniteOnKill] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 8f + 4f * itemCount,
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                    new Test(
                        calculateStat: (itemCount) => 1.5f + 1.5f * itemCount,
                        statText: "Duration Increase"
                    ),
                },
                [ItemIndex.WardOnLevel] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 8f + 8f * itemCount,
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                },
                [ItemIndex.NovaOnHeal] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Soul Energy Increase"
                    ),
                },
                [ItemIndex.HealOnCrit] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 4f + itemCount * 4f,
                        statText: "Health per Crit",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.BleedOnHit] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 0.15f * itemCount,
                        statText: "Bleed Chance Increase"
                    ),
                },
                [ItemIndex.SlowOnHit] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Slow Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.EquipmentMagazine] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Bonus Charges",
                        formatter: new IntFormatter()
                    ),
                    new Test(
                        calculateStat: (itemCount) => 0.15f + 0.15f * itemCount,
                        statText: "Cooldown Decrease"
                    ),
                },
                [ItemIndex.GoldOnHit] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 2f * Run.instance.difficultyCoefficient,
                        statText: "Gold per Hit(*)",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.IncreaseHealing] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Healing Increase"
                    ),
                },
                [ItemIndex.PersonalShield] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 25f,
                        statText: "Shield Health Increase",
                        formatter: new IntFormatter("SP")
                    ),
                },
                [ItemIndex.ChainLightning] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 2f,
                        statText: "Total Bounces",
                        formatter: new IntFormatter()
                    ),
                    new Test(
                        calculateStat: (itemCount) => 20f + 2f * (itemCount),
                        statText: "Bounce Range",
                        formatter: new IntFormatter("m")
                    ),
                },
                [ItemIndex.TreasureCache] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Crate Count",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.BounceNearby] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 1f - 100f / (100f + 20f * itemCount),
                        statText: "Bounce Chance"
                    ),
                    new Test(
                        calculateStat: (itemCount) => 5f + itemCount * 5f,
                        statText: "Max Enemies Hooked",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.SprintBonus] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 0.1f + 0.2f * itemCount,
                        statText: "Speed Increase"
                    ),
                },
                [ItemIndex.SprintArmor] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 30f * itemCount,
                        statText: "Shield Point Increase",
                        formatter: new IntFormatter("SP")
                    ),
                },
                [ItemIndex.ShockNearby] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 2f * itemCount,
                        statText: "Total Bounces",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.BeetleGland] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Total Guards",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.ShieldOnly] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 0.5f + (itemCount - 1) * 0.25f,
                        statText: "Max Health Increase"
                    ),
                },
                [ItemIndex.StickyBomb] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 1.25f + 1.25f * itemCount,
                        statText: "Damage Increase"
                    ),
                    new Test(
                        calculateStat: (itemCount) => (0.025f + 0.025f * itemCount),
                        statText: "Proc Chance Increase"
                    ),
                },
                [ItemIndex.RepeatHeal] = new List<Test>()
                {
                    //TODO: need to get masters maxhealth to get actual heal amount
                    new Test(
                        calculateStat: (itemCount) => 0.1f / itemCount,
                        statText: "Health Fraction/s"
                    ),
                    new Test(
                        calculateStat: (itemCount) => 1 + itemCount,
                        statText: "Healing per Heal Increase"
                    ),
                },
                [ItemIndex.HeadHunter] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 3f + 5f * itemCount,
                        statText: "Empowering Duration"
                    ),
                },
                [ItemIndex.ExtraLife] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Extra Lives",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.AlienHead] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => Mathf.Round(1 - Mathf.Pow(0.75f, itemCount)),
                        statText: "Cooldown Reduction",
                        formatter: new PercentageFormatter(decimalPlaces: 0)
                    ),
                },
                [ItemIndex.Firework] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 4 + itemCount * 4,
                        statText: "Firework Count",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.Missile] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 3 * itemCount,
                        statText: "Missile Damage Increase",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.Infusion] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 100 * itemCount,
                        statText: "Max Possible Health",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.JumpBoost] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 10 * itemCount,
                        statText: "Boost Length",
                        formatter: new IntFormatter("m")
                    ),
                },
            };
        }

        private static readonly Dictionary<ItemIndex, List<Test>> testDefs;
    }

    public class Test
    {
        public Test(Func<int, float> calculateStat, string statText,
            IStatFormatter formatter = null)
        {
            CalculateStat = calculateStat;
            StatText = statText;
            Formatter = formatter ?? new PercentageFormatter();
        }

        public readonly Func<int, float> CalculateStat;
        public readonly IStatFormatter Formatter;

        public string StatText { get; }
    }

    public enum StatFormatRule
    {
        Percentage,
        Count,
        Radius,
    }
}