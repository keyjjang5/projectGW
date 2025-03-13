using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class RowR2Atk8Card : Card
    {
        public RowR2Atk8Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "RowR2Atk8Card";
            AddEffect(new RowR2AttackEffect("Row R2 Atk8", 8));
            SetImage();
            Description = "Target R2 Atk 8";
            cost = 1;
        }
    }
}