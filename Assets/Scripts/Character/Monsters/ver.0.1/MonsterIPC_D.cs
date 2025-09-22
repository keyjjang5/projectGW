using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// юс╫ц
using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterIPC_D : Monster
    {
        public MonsterIPC_D(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_008";
            name = "Small Warrior";

            scale = new Vector3(3.0f, 3.0f, 3.0f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.NormalAttack, 3, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A1", 3));

            Attacks.Add(new Attack(IconType.NormalAttack, 8, 0, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A2", 8));

            
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