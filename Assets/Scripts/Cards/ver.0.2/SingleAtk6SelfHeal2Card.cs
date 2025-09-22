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
            AddEffect(new SingleAttackEffect("Single Atk 14", 14));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new PlayerSelfMassShieldEffect("Mass Shield 4", 4));
            AddEffect(new CooperationEffect(temp, "Mass Shield 4", 4));

            SetImage();
            Description = "14 피해를 입힌다. <color=#36A0FF>협력</color> : 아군 전체에게 보호막 4";
            cost = 2;
        }
    }
}