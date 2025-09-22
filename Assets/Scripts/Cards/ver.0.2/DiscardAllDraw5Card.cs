using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class DiscardAllDraw5Card : Card
    {
        public DiscardAllDraw5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "DiscardAllDraw5Card";
            AddEffect(new DiscardAllEffect("discard all"));
            AddEffect(new DrawEffect("draw 5", 5));
            AddEffect(new RecoveryCostEffect("recover 3", 3));
            SetImage();
            Description = "현재 모든 패를 버리고 5장 드로우, 코스트 3 회복";
            cost = 3;
        }
    }
}