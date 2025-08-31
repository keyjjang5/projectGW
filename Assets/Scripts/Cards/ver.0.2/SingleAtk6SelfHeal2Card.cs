using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk6SelfHeal2Card : Card
    {
        public SingleAtk6SelfHeal2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk6SelfHeal2Card";
            AddEffect(new SingleAttackEffect("Single Atk 6", 6));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("Cooperation atk 2", 2));
            AddEffect(new CooperationEffect(temp, "Cooperation atk 2", 2));

            AddEffect(new PlayerSelfHealEffect("Self Heal 2", 2));

            SetImage();
            Description = "대상에게 6 피해를 입힌다. 자신의 체력을 2 회복한다. [협력] : 대상에게 2 피해를 입힌다.";
            cost = 1;
        }
    }
}