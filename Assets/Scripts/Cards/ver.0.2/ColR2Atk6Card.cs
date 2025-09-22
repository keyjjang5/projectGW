using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class ColR2Atk6Card : Card
    {
        public ColR2Atk6Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "ColR2Atk6Card";
            AddEffect(new RowR2AttackEffect("Row B2 Atk6", 6));
            SetImage();
            Description = "가로 두칸 범위-> 에 6 피해를 입힌다.";
            cost = 1;
        }
    }
}