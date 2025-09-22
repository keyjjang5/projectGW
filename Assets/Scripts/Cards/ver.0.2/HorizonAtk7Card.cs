using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class HorizonAtk7Card : Card
    {
        public HorizonAtk7Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "HorizonAtk7Card";
            AddEffect(new RowLineAttackEffect("Horizon Atk 12", 12));

            SetImage();
            Description = "가로 세칸에 12 피해를 입힌다.";
            cost = 2;
        }
    }
}