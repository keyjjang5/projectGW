using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// юс╫ц
using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterIPC_C : Monster
    {
        public MonsterIPC_C(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_007";
            name = "Small Mushroom";

            scale = new Vector3(1f, 1f, 1f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.NormalAttack, 6, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A1", 6));

            Attacks.Add(new Attack(IconType.NormalAttack, 4, 0, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A2", 4));
        }

        public override void FindAttack()
        {
            Attack returnValue;

            if (time % 2 == 1)
            {
                SetTarget(AttackType.Random);
                returnValue = Attacks[0];
            }
            else
            {

                SetTarget(AttackType.Random);
                returnValue = Attacks[1];
            }

            NowAttack = returnValue;

            CalcPower();
        }
    }
}