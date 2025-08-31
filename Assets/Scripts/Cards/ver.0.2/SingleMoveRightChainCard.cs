using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleMoveRightChainCard : Card
    {
        public SingleMoveRightChainCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleMoveRightChainCard";
            AddEffect(new SingleAttackEffect("Atk 5", 5));
            AddEffect(new SingleMoveRightEffect("Move right", 1));
            SetImage();
            Description = "5 피해를 입히고 오른쪽으로 이동시킨다.";
            cost = 0;
        }
    }
}