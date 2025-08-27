using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk16Card : Card
    {
        public SingleAtk16Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk16Card";
            AddEffect(new SingleAttackEffect("Target Atk 16", 16));
            SetImage();
            Description = "대상에게 피해 16";
            cost = 2;
        }
    }
}