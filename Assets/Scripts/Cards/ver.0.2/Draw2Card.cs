using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Draw2Card : Card
    {
        public Draw2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Draw2Card";
            AddEffect(new DrawEffect("draw 2", 2));
            SetImage();
            Description = "2 장을 뽑는다.";
            cost = 0;
        }
    }
}