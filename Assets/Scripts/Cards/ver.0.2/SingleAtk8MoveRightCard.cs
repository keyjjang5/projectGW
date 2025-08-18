using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk8MoveRightCard : Card
    {
        public SingleAtk8MoveRightCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk8MoveRightCard";
            AddEffect(new SingleAttackEffect("Target Atk 8", 8));
            AddEffect(new SingleMoveRightEffect("Target MoveRight", 1));
            SetImage();
            Description = "대상에게 피해 8를 입히고 오른쪽으로 이동시킨다.";
            cost = 1;
        }
    }
}