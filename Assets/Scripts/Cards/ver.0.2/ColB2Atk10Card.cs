using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class ColB2Atk10Card : Card
    {
        public ColB2Atk10Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "ColB2Atk10Card";
            AddEffect(new ColB2AttackEffect("Row B2 Atk10", 10));
            SetImage();
            Description = "대상 기준으로 1*2 범위에 10 피해를 입힌다.";
            cost = 1;
        }
    }
}