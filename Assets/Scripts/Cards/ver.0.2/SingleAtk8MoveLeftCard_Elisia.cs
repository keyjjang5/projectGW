using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk8MoveLeftCard_Elisia : Card
    {
        public SingleAtk8MoveLeftCard_Elisia(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk8MoveLeftCard_Elisia";
            AddEffect(new SingleAttackEffect("Target Atk 8", 8));
            AddEffect(new SingleMoveLeftEffect("Target MoveLeft", 1));
            SetImage();
            Description = "피해 8를 입히고 왼쪽으로 이동시킨다.";
            cost = 1;
        }
    }
}