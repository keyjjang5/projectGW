using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class XAtk14Card : Card
    {
        public XAtk14Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "XAtk14Card";
            AddEffect(new XAttackEffect("X Atk 14", 14));
            SetImage();
            Description = "X범위에 14 피해";
            cost = 2;
        }
    }
}