using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassHeal4Card : Card
    {
        public MassHeal4Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassHeal4Card";
            AddEffect(new MassHealEffect("Mass Heal 4", 4));
            SetImage();
            Description = "아군 전체를 4 회복시킨다.";
            cost = 1;
        }
    }
}