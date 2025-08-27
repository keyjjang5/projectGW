using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk11Card : Card
    {
        public SingleAtk11Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk11Card";
            AddEffect(new SingleAttackEffect("single atk 11", 11));
            SetImage();
            Description = "대상에게 피해 11를 입힌다.";
            cost = 1;
        }
    }
}