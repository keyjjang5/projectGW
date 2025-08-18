using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class CrossAtk15Card : Card
    {
        public CrossAtk15Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "CrossAtk15Card";
            AddEffect(new CrossAttackEffect("Cross Atk 15", 15));
            SetImage();
            Description = "십자범위에 15 피해";
            cost = 3;
        }
    }
}