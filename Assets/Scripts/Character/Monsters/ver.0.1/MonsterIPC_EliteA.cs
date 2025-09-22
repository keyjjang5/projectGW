using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// юс╫ц
using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterIPC_EliteA : Monster
    {
        public MonsterIPC_EliteA(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_009";
            name = "Big Mushroom";

            scale = new Vector3(3.3f, 3.3f, 3.3f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.MassAttack, 7, 0, "A1"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new MassAttackEffect("A1", 7));

            Attacks.Add(new Attack(IconType.Shield, 16, 0, "A2"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfShieldEffect("A2", 16));

            Attacks.Add(new Attack(IconType.NormalAttack, 16, 0, "A3"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A3", 16));
        }

        public override void FindAttack()
        {
            Attack returnValue;

            switch(time % 3)
            {
                case (1):
                    SetTarget(AttackType.All);
                    returnValue = Attacks[0];
                    break;
                case (2):
                    SetTarget(AttackType.Self);
                    returnValue = Attacks[1];
                    break;
                case (0):
                    SetTarget(AttackType.Random);
                    returnValue = Attacks[2];
                    break;
                default:
                    returnValue = null;
                    Debug.Log("FindAttack Error");
                    break;
            }

            NowAttack = returnValue;

            CalcPower();
        }
    }
}