using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GWEffectVer_0_2;

namespace GWMonsterVer_0_1
{
    public class MonsterA : Monster
    {
        public MonsterA(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
        {
            id = "M_001";
            name = "BoomMushroom";

            scale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        public override void SetAttacks()
        {
            // 필요한 만큼 반복
            Attacks.Add(new Attack(IconType.UnknownAttack, 10, 99, "SuisideAttack"));
            // 필요한 만큼 반복
            Attacks[Attacks.Count - 1].AddBattleEffect(new MassAttackEffect("mass atk 10", 10));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SelfKillEffect("suiside", 0));

            Attacks.Add(new global::Attack(IconType.NormalAttack, 6, 0, "atk 6"));
            Attacks[Attacks.Count - 1].AddBattleEffect(new SingleAttackEffect("atk 6", 6));

            //BattleEffects.Add(new MassAttackEffect(10));
            //BattleEffects.Add(new SuisideEffect());
            //BattleEffects.Add(new AttackEffect(6));
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