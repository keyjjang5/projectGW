using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// юс╫ц
using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterIPC_B : Monster
    {
        public MonsterIPC_B(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_006";
            name = "Mushroom";

            scale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.NormalAttack, 9, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A1", 9));

            Attacks.Add(new Attack(IconType.PlusAttack, 4, 0, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A2", 4));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfHealEffect("A2", 4));
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