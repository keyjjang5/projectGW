using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// юс╫ц
using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterC : Monster
    {
        public MonsterC(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_003";
            name = "MercenaryRemnants";

            scale = new Vector3(2.5f, 2.5f, 2.5f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.NormalAttack, 10, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A1", 10));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfKnockbackEffect("A1", 1));

            Attacks.Add(new Attack(IconType.Buff, 8, 2, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfHealEffect("A2", 8));

            Attacks.Add(new Attack(IconType.NormalAttack, 6, 0, "A3"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A3", 6));
        }

        public override void FindAttack()
        {
            Attack returnValue;

            if (NowHp <= MaxHp / 10 * 3
                && BattleField.Instance.SearchMonster(Pos + BattleField.Instance.divisionNum) == null
                && (Pos + BattleField.Instance.divisionNum) < Mathf.Pow(BattleField.Instance.divisionNum, 2))
            {
                SetTarget(AttackType.Random);
                returnValue = Attacks[0];
            }
            else if (Attacks[1].IsActive() && NowHp <= MaxHp / 2)
            {
                SetTarget(AttackType.Self);
                returnValue = Attacks[1];
            }
            else
            {
                SetTarget(AttackType.Random);
                returnValue = Attacks[2];
            }

            NowAttack = returnValue;

            CalcPower();
        }
    }
}