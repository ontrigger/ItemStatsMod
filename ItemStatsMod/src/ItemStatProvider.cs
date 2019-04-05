using System;
using System.Collections.Generic;
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

                var statValueStr = string.Empty;
                switch (subItemStat.FormattingRule)
                {
                    case StatFormatRule.Percentage:
                        statValueStr = Math.Round(statValue * 100f, 2).ToString("0.##") + "%";
                        break;
                    case StatFormatRule.Count:
                        statValueStr = Math.Round(statValue).ToString();
                        break;
                    case StatFormatRule.Radius:
                        statValueStr = Math.Round(statValue) + "m";
                        break;
                }

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
                    new Test(calculateStat: (itemCount) => (1f - 1f / (0.15f * itemCount + 1f)))
                },


                [ItemIndex.Hoof] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 0.14f,
                        statText: "Walk Speed Increase")
                },


                [ItemIndex.Syringe] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 0.15f,
                        statText: "Attack Speed Increase")
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
                        formattingRule: StatFormatRule.Radius
                    )
                },
                [ItemIndex.CritGlasses] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 0.1f,
                        statText: "Crit Chance Increase"
                    )
                },
                [ItemIndex.Feather] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Total Jumps",
                        formattingRule: StatFormatRule.Count
                    )
                },
                [ItemIndex.Seed] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Total Heal Hp",
                        formattingRule: StatFormatRule.Count
                    )
                },
                [ItemIndex.GhostOnKill] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 30f,
                        statText: "Ghost Duration (seconds)",
                        formattingRule: StatFormatRule.Count
                    )
                },
                [ItemIndex.Knurl] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 40f,
                        statText: "Maximum Health",
                        formattingRule: StatFormatRule.Count
                    ),
                    new Test(
                        calculateStat: (itemCount) => itemCount * 1.6f,
                        statText: "Health per Second"
                    ),
                },
                [ItemIndex.Clover] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Additional Rerolls",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.Medkit] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 10f,
                        statText: "Health Healed",
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.Talisman] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 2f + itemCount * 2f,
                        statText: "Cooldown Reduction",
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.SecondarySkillMagazine] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Bonus Stock",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.UtilitySkillMagazine] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 2f,
                        statText: "Bonus Charges",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.AutoCastEquipment] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 0.5f + itemCount * 0.5f,
                        statText: "Cooldown Decrease"
                    ),
                },
                [ItemIndex.KillEliteFrenzy] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 1f + itemCount * 2f,
                        statText: "Frenzy Duration",
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Radius
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
                        formattingRule: StatFormatRule.Radius
                    ),
                    new Test(
                        calculateStat: (itemCount) => 1.5f + 1.5f * itemCount,
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.WardOnLevel] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 8f + 8f * itemCount,
                        statText: "Radius Increase",
                        formattingRule: StatFormatRule.Radius
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
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.EquipmentMagazine] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Bonus Charges",
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.ChainLightning] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount * 2f,
                        statText: "Total Bounces",
                        formattingRule: StatFormatRule.Count
                    ),
                    new Test(
                        calculateStat: (itemCount) => 20f + 2f * (itemCount),
                        statText: "Bounce Range",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.TreasureCache] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Crate Count",
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Count
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
                        statText: "Armor Point Increase",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.ShockNearby] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 2f * itemCount,
                        statText: "Total Bounces",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.BeetleGland] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => itemCount,
                        statText: "Total Guards",
                        formattingRule: StatFormatRule.Count
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
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.AlienHead] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 0.25f + 0.25f * (itemCount - 1),
                        statText: "Cooldown Reduction"
                    ),
                },
                [ItemIndex.Firework] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 4 + itemCount * 4,
                        statText: "Firework Count",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.Missile] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 3 * itemCount,
                        statText: "Missile Damage Increase",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.Infusion] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 100 * itemCount,
                        statText: "Max Possible Health",
                        formattingRule: StatFormatRule.Count
                    ),
                },
                [ItemIndex.JumpBoost] = new List<Test>()
                {
                    new Test(
                        calculateStat: (itemCount) => 10 * itemCount,
                        statText: "Boost Length",
                        formattingRule: StatFormatRule.Radius
                    ),
                },
            };
        }

        private static readonly Dictionary<ItemIndex, List<Test>> testDefs;
    }

    public class Test
    {
        public Test(Func<int, float> calculateStat, string statText = "Proc Chance",
            StatFormatRule formattingRule = StatFormatRule.Percentage)
        {
            CalculateStat = calculateStat;
            StatText = statText;
            FormattingRule = formattingRule;
        }

        public readonly Func<int, float> CalculateStat;
        public readonly StatFormatRule FormattingRule;
        public string StatText { get; }
    }

    public enum StatFormatRule
    {
        Percentage,
        Count,
        Radius,
    }
}