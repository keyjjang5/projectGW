using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class TargetShield7Card : Card
    {
        public TargetShield7Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "TargetShield7Card";
            AddEffect(new SingleShieldEffect("singleShield7", 7));
            SetImage();
            Description = "Target Def 7";
            cost = 1;
        }
    }
}