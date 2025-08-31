using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleMoveLeftIsolationCard : Card
    {
        public SingleMoveLeftIsolationCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleMoveLeftIsolationCard";

            AddEffect(new SingleAttackEffect("Atk 5", 5));
            AddEffect(new SingleMoveLeftEffect("Move left", 1));            
            
            SetImage();
            Description = "5피해를 입히고 왼쪽으로 이동시킨다.";
            cost = 0;
        }
    }
}