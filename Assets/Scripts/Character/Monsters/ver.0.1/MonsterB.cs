using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterB : Monster
    {
        public MonsterB(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_002";
            name = "PoisonMushroom";
            scale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        public override void SetAttacks()
        {
            Attacks.Add(new Attack(IconType.UnknownAttack, 1, 99, "Suiside Poison"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new MassAttackEffect("mass atk 1", 1));
            Attacks[Attacks.Count - 1].AddBattleEffect(new MassPoisonEffect("A1", 5));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfKillEffect());

            Attacks.Add(new Attack(IconType.UnknownAttack, 4, 3, "Poison"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A2", 4));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SinglePoisonEffect("A2", 2));

            Attacks.Add(new global::Attack(IconType.NormalAttack, 5, 0, "atk 5"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("A3", 5));
        }

        public override void FindAttack()
        {
            Attack returnValue;

            // 필요한 만큼 반복
            if (NowHp <= MaxHp / 4)
            {
                SetTarget(AttackType.All);
                returnValue = Attacks[0];
            }
            else if(Attacks[1].IsActive())
            {
                SetTarget(AttackType.Random);
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