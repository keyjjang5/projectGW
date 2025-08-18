using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class VerticalAtk15Card : Card
    {
        public VerticalAtk15Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "VerticalAtk15Card";
            AddEffect(new ColLineAttackEffect("Vertical Atk 15", 15));
            SetImage();
            Description = "세로범위에 15 피해";
            cost = 2;
        }
    }
}