using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk9MoveRightCard : Card
    {
        public SingleAtk9MoveRightCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk9MoveRightCard";
            AddEffect(new SingleAttackEffect("Target Atk 9", 9));
            AddEffect(new SingleMoveRightEffect("Target MoveRight", 1));
            SetImage();
            Description = "대상에게 피해 9를 입히고 오른쪽으로 이동시킨다.";
            cost = 1;
        }
    }
}