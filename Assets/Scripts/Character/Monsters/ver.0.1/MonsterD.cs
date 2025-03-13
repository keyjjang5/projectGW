using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// юс╫ц
using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterD : Monster
    {
        public MonsterD(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_004";
            name = "HuntingDog";

            scale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.Buff, 0, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfHealEffect("A1", (int)MaxHp / 2));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfAttackIncreaseEffect("A1", 50));

            Attacks.Add(new Attack(IconType.NormalAttack, 4, 0, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new WeakestAttackEffect("A2", 4));
        }

        public override void FindAttack()
        {
            Attack returnValue;

            if (time == 3)
            {
                SetTarget(AttackType.Self);
                returnValue = Attacks[0];
            }
            else
            {

                SetTarget(AttackType.Weakest);
                returnValue = Attacks[1];
            }

            NowAttack = returnValue;

            CalcPower();
        }
    }
}