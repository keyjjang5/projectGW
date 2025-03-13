using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class ColB2Atk15Card : Card
    {
        public ColB2Atk15Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "ColB2Atk15Card";
            AddEffect(new ColB2AttackEffect("Row B2 Atk15", 15));
            SetImage();
            Description = "Target B2 Atk 15";
            cost = 2;
        }
    }
}