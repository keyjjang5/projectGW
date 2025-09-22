using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Draw1Card_Catherin : Card
    {
        public Draw1Card_Catherin(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Draw1Card_Catherin";
            AddEffect(new DrawEffect("draw 1", 1));
            SetImage();
            Description = "1 장을 뽑는다.";
            cost = 0;
        }
    }
}