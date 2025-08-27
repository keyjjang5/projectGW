using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk7KnockbackCard : Card
    {
        public SingleAtk7KnockbackCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk7KnockbackCard";
            AddEffect(new SingleAttackEffect("Target Atk 7", 7));
            AddEffect(new SingleKnockbackEffect("Target KnockBack", 1));
            SetImage();
            Description = "대상에게 피해 7를 입히고 뒤로 이동시킨다.";
            cost = 1;
        }
    }
}