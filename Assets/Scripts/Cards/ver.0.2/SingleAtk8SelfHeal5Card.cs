using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk8SelfHeal5Card : Card
    {
        public SingleAtk8SelfHeal5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk8SelfHeal5Card";
            AddEffect(new SingleAttackEffect("Single Atk 8", 8));
            AddEffect(new PlayerSelfHealEffect("Self Heal 5", 5));
            SetImage();
            Description = "대상에게 8 피해를 입힌다. 자신의 체력을 5 회복한다.";
            cost = 1;
        }
    }
}