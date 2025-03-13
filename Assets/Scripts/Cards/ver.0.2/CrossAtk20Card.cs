using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class CrossAtk20Card : Card
    {
        public CrossAtk20Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "CrossAtk20Card";
            AddEffect(new CrossAttackEffect("Cross Atk 20", 20));
            SetImage();
            Description = "Target Cross Atk 20";
            cost = 2;
        }
    }
}