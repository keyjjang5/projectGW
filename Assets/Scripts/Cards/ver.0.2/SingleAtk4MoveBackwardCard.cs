using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk4MoveBackwardCard : Card
    {
        public SingleAtk4MoveBackwardCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk4MoveBackwardCard";
            AddEffect(new SingleAttackEffect("Target Atk 4", 4));
            AddEffect(new SingleKnockbackEffect("Target MoveBackward", 1));
            SetImage();
            Description = "대상에게 피해 4를 입히고 뒤로 이동시킨다.";
            cost = 1;
        }
    }
}