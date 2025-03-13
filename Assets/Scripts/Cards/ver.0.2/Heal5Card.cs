using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Heal5Card : Card
    {
        public Heal5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Heal5Card";
            AddEffect(new SingleHealEffect("target Heal 5", 5));
            SetImage();
            Description = "Target Heal 5";
            cost = 1;
        }
    }
}