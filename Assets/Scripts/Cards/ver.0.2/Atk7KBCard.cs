using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Atk7KBCard : Card
    {
        public Atk7KBCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Atk7KBCard";
            AddEffect(new SingleAttackEffect("cardTest1", 7));
            AddEffect(new SingleKnockbackEffect("SingleKnockback", 1));
            SetImage();
            Description = "Target Atk 7 & knockback";
            cost = 1;
        }
    }
}