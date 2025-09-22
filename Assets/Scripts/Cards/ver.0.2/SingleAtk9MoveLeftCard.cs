using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk9MoveLeftCard : Card
    {
        public SingleAtk9MoveLeftCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk9MoveLeftCard";
            AddEffect(new SingleAttackEffect("Target Atk 9", 9));
            AddEffect(new SingleMoveLeftEffect("Target MoveLeft", 1));
            SetImage();
            Description = "피해 9를 입히고 왼쪽으로 이동시킨다.";
            cost = 1;
        }
    }
}