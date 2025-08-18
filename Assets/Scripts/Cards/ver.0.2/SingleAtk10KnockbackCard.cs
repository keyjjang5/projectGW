using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk12Card : Card
    {
        public SingleAtk12Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk12Card";
            AddEffect(new SingleAttackEffect("cardTest1", 12));
            SetImage();
            Description = "대상에게 피해 12를 입힌다.";
            cost = 1;
        }
    }
}