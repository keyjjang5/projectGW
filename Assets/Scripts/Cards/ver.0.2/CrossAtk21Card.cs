using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class CrossAtk21Card : Card
    {
        public CrossAtk21Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "CrossAtk21Card";
            AddEffect(new CrossAttackEffect("Cross Atk 21", 21));
            SetImage();
            Description = "십자범위에 21 피해";
            cost = 3;
        }
    }
}