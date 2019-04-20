using System;
using System.Collections.Generic;
using System.Linq;
using ItemStats.ValueFormatters;
using ItemStats.ValueFormatters.Decorators;
using ItemStatsMod.ValueFormatters;
using RoR2;
using UnityEngine;
using static ItemStats.ContextProvider;
using Console = RoR2.Console;

namespace ItemStats
{
    public static class ItemStatProvider
    {
        public static string ProvideStatsForItem(ItemIndex index, int count)
        {
            var itemStatList = testDefs.ContainsKey(index) ? testDefs[index] : null;

            if (itemStatList == null)
            {
                return "NOT IMPL";
            }

            var fullStatText = string.Empty;
            foreach (ItemStat subItemStat in itemStatList)
            {
                var statValue = subItemStat.GetInitialStat(count) + subItemStat.GetIndividualStats(count).Sum();

                var statValueStr = subItemStat.Format(statValue);

                statValueStr += subItemStat.FormatSubStats(count);


                if (itemStatList.IndexOf(subItemStat) == itemStatList.Count - 1)
                {
                    // this is the last line
                    // TextMeshPro richtext modifier that allows me to align the stack counter on the right
                    fullStatText += $"<align=left>{subItemStat.StatText}: {statValueStr}<line-height=0>";
                }
                else
                {
                    fullStatText += $"{subItemStat.StatText}: {statValueStr}\n";
                }
            }

            return $"{fullStatText}\n<align=right>({count} stacks)<line-height=1em>";
        }

        static ItemStatProvider()
        {
            testDefs = new Dictionary<ItemIndex, List<ItemStat>>
            {
                [ItemIndex.Bear] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((count) => (1f - 1f / (0.15f * count + 1f))),
                        statText: "Block Chance"
                    ),
                },


                [ItemIndex.Hoof] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 0.14f),
                        statText: "Movement Speed Increase"
                    )
                },


                [ItemIndex.Syringe] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((count) => count * 0.15f),
                        statText: "Attack Speed Increase"
                    )
                },

                [ItemIndex.Mushroom] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula(count => 0.0225f + 0.0225f * count),
                        statText: "Healing Per Second",
                        // TODO: use a decorator instead of additional param for the formatter
                        formatter: new PercentageFormatter(maxValue: 1f)
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 1.5f + 1.5f * itemCount),
                        statText: "Area Increase",
                        formatter: new IntFormatter("m")
                    )
                },
                [ItemIndex.CritGlasses] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 0.1f),
                        statText: "Additional Crit Chance",
                        formatter: new PercentageFormatter(maxValue: 1f)
                    )
                },
                [ItemIndex.Feather] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Total Additional  Jumps",
                        formatter: new IntFormatter()
                    )
                },
                [ItemIndex.Seed] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Total Heal Hp",
                        formatter: new IntFormatter("HP")
                    )
                },
                [ItemIndex.GhostOnKill] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 30f),
                        statText: "Ghost Duration",
                        formatter: new IntFormatter("s")
                    ),
                    new ItemStat(
                        formula: new Formula(itemCount => 0.1f),
                        statText: "Ghost Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.Knurl] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 40f),
                        statText: "Bonus Health",
                        formatter: new IntFormatter("HP")
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 1.6f),
                        statText: "Additional Regeneration",
                        formatter: new IntFormatter("HP/s")
                    ),
                },
                [ItemIndex.Clover] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Additional Rerolls",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.Medkit] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 10f),
                        statText: "Health Healed",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.Crowbar] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 1.5f + 0.3f * (itemCount - 1)),
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.Tooth] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 4 * itemCount),
                        statText: "Heal Amount",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.Talisman] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 2f + itemCount * 2f),
                        statText: "Cooldown Reduction",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.Bandolier] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 1f - 1f / Mathf.Pow(itemCount + 1, 0.33f)),
                        statText: "Drop Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.IceRing] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 1.25f + 1.25f * itemCount),
                        statText: "Damage Increase"
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.08f),
                        statText: "Proc Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.FireRing] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 2.5f + 2.5f * itemCount),
                        statText: "Damage Increase"
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.08f),
                        statText: "Proc Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.WarCryOnMultiKill] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 2f + 4f * itemCount),
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.SprintOutOfCombat] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 0.3f),
                        statText: "Speed Increase"
                    ),
                },
                [ItemIndex.StunChanceOnHit] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 1f - 1f / (0.05f * itemCount + 1f)),
                        statText: "Stun Chance Increase",
                        formatter: new PercentageFormatter(maxValue: 1f),
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.WarCryOnCombat] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 2f + 4f * itemCount),
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.SecondarySkillMagazine] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Bonus Stock",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.UtilitySkillMagazine] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 2f),
                        statText: "Bonus Charges",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.AutoCastEquipment] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 1 - Mathf.Pow(0.5f, itemCount)),
                        statText: "Cooldown Decrease",
                        formatter: new PercentageFormatter(0)
                    ),
                },
                [ItemIndex.KillEliteFrenzy] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 1f + itemCount * 2f),
                        statText: "Frenzy Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.BossDamageBonus] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.2f + 0.1f * (itemCount - 1)),
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.ExplodeOnDeath] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 12f + 2.4f * (itemCount - 1f)),
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 3.5f * (1f + (itemCount - 1) * 0.8f)),
                        statText: "Damage Increase"
                    ),
                },
                [ItemIndex.HealWhileSafe] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 2.5f + (itemCount - 1) * 1.5f),
                        statText: "Regeneration Increase"
                    ),
                },
                [ItemIndex.IgniteOnKill] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 8f + 4f * itemCount),
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 1.5f + 1.5f * itemCount),
                        statText: "Duration Increase"
                    ),
                },
                [ItemIndex.WardOnLevel] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 8f + 8f * itemCount),
                        statText: "Radius Increase",
                        formatter: new IntFormatter("m")
                    ),
                },
                [ItemIndex.NovaOnHeal] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Soul Energy"
                    ),
                },
                [ItemIndex.HealOnCrit] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 4f + itemCount * 4f),
                        statText: "Health per Crit",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.BleedOnHit] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.15f * itemCount),
                        statText: "Bleed Chance Increase",
                        formatter: new PercentageFormatter(maxValue: 1f)
                    ),
                },
                [ItemIndex.SlowOnHit] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Slow Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.EquipmentMagazine] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Bonus Charges",
                        formatter: new IntFormatter()
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 1 - Mathf.Pow(0.85f, itemCount)),
                        statText: "Cooldown Decrease"
                    ),
                },
                [ItemIndex.GoldOnHit] = new List<ItemStat>()
                {
                    new ItemStat(
                        //TODO: make run a modifier
                        formula: new Formula((itemCount) => itemCount * 3f * Run.instance.difficultyCoefficient),
                        statText: "Gold per Hit(*)",
                        formatter: new IntFormatter()
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.3f),
                        statText: "Proc Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.IncreaseHealing] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Healing Increase"
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.25f),
                        statText: "Proc Chance",
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.PersonalShield] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 25f),
                        statText: "Shield Health Increase",
                        formatter: new IntFormatter("SP")
                    ),
                },
                [ItemIndex.ChainLightning] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount * 2f),
                        statText: "Total Bounces",
                        formatter: new IntFormatter()
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 20f + 2f * (itemCount)),
                        statText: "Bounce Range",
                        formatter: new IntFormatter("m")
                    ),
                },
                [ItemIndex.TreasureCache] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 80f / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f))),
                        statText: "Common Chance",
                        formatter: new PercentageFormatter(maxValue: 1f)
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) =>
                            (20f * itemCount) / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f))),
                        statText: "Uncommon Chance",
                        formatter: new PercentageFormatter(maxValue: 1f)
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) =>
                            (Mathf.Pow(itemCount, 2f)) / (80f + 20f * itemCount + Mathf.Pow(itemCount, 2f))),
                        statText: "Rare Chance",
                        formatter: new PercentageFormatter(maxValue: 1f)
                    ),
                },
                [ItemIndex.BounceNearby] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 1f - 100f / (100f + 20f * itemCount)),
                        statText: "Hook Chance",
                        modifiers: Modifiers.Clover
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 5f + itemCount * 5f),
                        statText: "Max Enemies Hooked",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.SprintBonus] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.1f + 0.2f * itemCount),
                        statText: "Speed Increase"
                    ),
                },
                [ItemIndex.SprintArmor] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 30f * itemCount),
                        statText: "Sprint Bonus Armor",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.ShockNearby] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 2f * itemCount),
                        statText: "Total Bounces",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.BeetleGland] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Total Guards",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.ShieldOnly] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.5f + (itemCount - 1) * 0.25f),
                        statText: "Max Health Increase"
                    ),
                },
                [ItemIndex.StickyBomb] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 1.25f + 1.25f * itemCount),
                        statText: "Damage Increase"
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => (0.025f + 0.025f * itemCount)),
                        statText: "Proc Chance Increase",
                        formatter: new PercentageFormatter(maxValue: 1f),
                        modifiers: Modifiers.Clover
                    ),
                },
                [ItemIndex.RepeatHeal] = new List<ItemStat>()
                {
                    //TODO: need to get masters maxhealth to get actual heal amount
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.1f / itemCount),
                        statText: "Health Fraction/s"
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 1 + itemCount),
                        statText: "Healing per Heal Increase"
                    ),
                },
                [ItemIndex.HeadHunter] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 3f + 5f * itemCount),
                        statText: "Empowering Duration",
                        formatter: new IntFormatter("s")
                    ),
                },
                [ItemIndex.ExtraLife] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => itemCount),
                        statText: "Extra Lives",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.AlienHead] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => Mathf.Round(1 - Mathf.Pow(0.75f, itemCount))),
                        statText: "Cooldown Reduction",
                        formatter: new PercentageFormatter(decimalPlaces: 0)
                    ),
                },
                [ItemIndex.Firework] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 4 + itemCount * 4),
                        statText: "Firework Count",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.Missile] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 3 * itemCount),
                        statText: "Missile Damage Increase",
                        formatter: new IntFormatter()
                    ),
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.1f),
                        statText: "Proc Chance",
                        formatter: new IntFormatter()
                    ),
                },
                [ItemIndex.Infusion] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 100 * itemCount),
                        statText: "Max Additional Health",
                        formatter: new IntFormatter("HP")
                    ),
                },
                [ItemIndex.JumpBoost] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 10 * itemCount),
                        statText: "Boost Length",
                        formatter: new IntFormatter("m")
                    ),
                },
                [ItemIndex.AttackSpeedOnCrit] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.3f * itemCount),
                        statText: "Max Attack Speed"
                    )
                },
                [ItemIndex.Icicle] = new List<ItemStat>()
                {
                    new ItemStat(
                        formula: new Formula((itemCount) => 0.25f * (0.5f + 0.5f * itemCount)),
                        statText: "Icicle Damage"
                    )
                }
            };
        }

        private static readonly Dictionary<ItemIndex, List<ItemStat>> testDefs;
    }

    // this is literally just a wrapper around func coz i couldnt make composition
    // work in a concise way
    // it's a mess
    public class Formula
    {
        // no generics coz they look ugly and it takes precious space typing them in the ctor
        public readonly Func<float, float> Func;

        public Formula(Func<float, float> func)
        {
            Func = func;
        }

        public Formula Compose(Formula f) => new Formula(v => f.Func(Func(v)));

        public Formula Compose(Func<float, float> f) => new Formula(v => f(Func(v)));

        public static Formula operator +(Formula f1, Formula f2) => new Formula(v => f2.Func(f1.Func(v)));

        public static Formula operator +(Formula f1, Func<float, float> f2) => new Formula(v => f2(f1.Func(v)));
    }

    public class ItemStat
    {
        private readonly Formula _formula;
        public readonly IStatFormatter Formatter;
        public string StatText { get; }
        private Modifier[] StatModifiers { get; }


        public ItemStat(Formula formula, string statText,
            IStatFormatter formatter = null, params Modifier[] modifiers)
        {
            _formula = formula;
            StatText = statText;
            Formatter = formatter ?? new PercentageFormatter();
            StatModifiers = modifiers;
        }

        public float GetInitialStat(float count)
        {
            return _formula.Func(count);
        }

        public IEnumerable<float> GetIndividualStats(float count)
        {
            var originalValue = GetInitialStat(count);
            foreach (var stat in StatModifiers)
            {
                yield return stat.GetModifiedValue(originalValue) - originalValue;
            }
        }

        public string Format(float statValue)
        {
            return Formatter.Format(statValue);
        }

        public string FormatSubStats(float count)
        {
            var originalValue = _formula.Func(count);

            var formattedValue = String.Empty;
            foreach (var stat in StatModifiers)
            {
                var valueDiff = stat.GetModifiedValue(originalValue) - originalValue;
                Debug.Log("Value diff is " + valueDiff);
                if (Math.Round(valueDiff, 3) > 0)
                {
                    formattedValue += stat.GetFormattedValue(valueDiff);
                }
            }

            return formattedValue;
        }
    }

    static class Modifiers
    {
        public static Modifier Clover = new Modifier(
            result => 1 - Mathf.Pow(1 - result, 1 + CountItems(ItemIndex.Clover)),
            new ModifierFormatter("from Clover")
        );
    }

    public class Modifier
    {
        private readonly Func<float, float> _func;
        private readonly IStatFormatter _formatter;

        public Modifier(Func<float, float> func, IStatFormatter formatter)
        {
            _func = func;
            _formatter = formatter;
        }

        public float GetModifiedValue(float originalValue)
        {
            return _func(originalValue);
        }

        public string GetFormattedValue(float value)
        {
            return _formatter.Format(value);
        }
    }
}