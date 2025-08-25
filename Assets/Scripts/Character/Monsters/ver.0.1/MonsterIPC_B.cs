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
            Attacks.Add(new Attack(IconType.NormalAttack, 8, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A1", 8));

            Attacks.Add(new Attack(IconType.Recovery, 10, 0, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfHealEffect("A2", 10));
        }

        public override void FindAttack()
        {
            Attack returnValue;

            if (Random.Range(0, 2) == 0)
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