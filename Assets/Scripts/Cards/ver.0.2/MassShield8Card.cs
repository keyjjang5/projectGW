using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassShield8Card : Card
    {
        public MassShield8Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassShield8Card";
            AddEffect(new MassShieldEffect("Mass Shield 8", 8));
            SetImage();
            Description = "아군 전체에게 보호막 8 부여한다.";
            cost = 2;
        }
    }
}