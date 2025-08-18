using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk25Card : Card
    {
        public SingleAtk25Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk25Card";
            AddEffect(new SingleAttackEffect("Target Atk 25", 25));
            SetImage();
            Description = "대상에게 피해 25";
            cost = 2;
        }
    }
}