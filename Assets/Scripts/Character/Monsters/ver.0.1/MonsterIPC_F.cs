using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// юс╫ц
using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterIPC_F : Monster
    {
        public MonsterIPC_F(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_011";
            name = "Enhanced Mushroom";

            scale = new Vector3(2.1f, 2.1f, 2.1f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.PlusAttack, 6, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A1", 6));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfHealEffect("A1", 4));

            Attacks.Add(new Attack(IconType.NormalAttack, 11, 0, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A2", 11));
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