using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassHeal3Card : Card
    {
        public MassHeal3Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassHeal3Card";
            AddEffect(new MassHealEffect("Mass Heal 3", 3));
            SetImage();
            Description = "Mass Heal 3";
            cost = 1;
        }
    }
}