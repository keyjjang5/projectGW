using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Random3Atk6Card : Card
    {
        public Random3Atk6Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Random3Atk6Card";
            AddEffect(new RandomAttackEffect("random attack 6_1", 6));
            AddEffect(new RandomAttackEffect("random attack 6_2", 6));
            AddEffect(new RandomAttackEffect("random attack 6_3", 6));
            SetImage();
            Description = "Random atk 6 * 3";
            cost = 1;
        }
    }
}