using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// юс╫ц
using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterIPC_A : Monster
    {
        public MonsterIPC_A(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_005";
            name = "Thief";

            scale = new Vector3(3.5f, 3.5f, 3.5f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.NormalAttack, 13, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A1", 13));

            Attacks.Add(new Attack(IconType.Shield, 10, 0, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfShieldEffect("A2", 10));
        }

        public override void FindAttack()
        {
            Attack returnValue;

            if (time % 2 == 0)
            {
                SetTarget(AttackType.Random);
                returnValue = Attacks[0];
            }
            else
            {

                SetTarget(AttackType.Self);
                returnValue = Attacks[1];
            }

            NowAttack = returnValue;

            CalcPower();
        }
    }
}