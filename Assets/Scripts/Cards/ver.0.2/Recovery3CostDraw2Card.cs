using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Recovery3CostDraw2Card : Card
    {
        public Recovery3CostDraw2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Recovery3CostDraw2Card";
            AddEffect(new RecoveryCostEffect("Recovery Cost 3", 3));
            AddEffect(new DrawEffect("draw 2", 2));
            SetImage();
            Description = "3 코스트 회복하고 2 장을 뽑는다.";
            cost = 2;
        }
    }
}