using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Draw1Cost1Card : Card
    {
        public Draw1Cost1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Draw1Cost1Card";
            AddEffect(new DrawEffect("draw 1", 1));
            AddEffect(new RecoveryCostEffect("recover 1", 1));
            SetImage();
            Description = "1 장을 뽑는다. 1 코스트 회복";
            cost = 2;
        }
    }
}