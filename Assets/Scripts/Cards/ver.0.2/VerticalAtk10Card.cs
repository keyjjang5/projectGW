using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class VerticalAtk10Card : Card
    {
        public VerticalAtk10Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "VerticalAtk10Card";
            AddEffect(new ColLineAttackEffect("Vertical Atk 10", 10));
            SetImage();
            Description = "세로범위에 10 피해";
            cost = 2;
        }
    }
}