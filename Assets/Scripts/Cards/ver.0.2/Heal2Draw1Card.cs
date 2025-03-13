using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Heal2Draw1Card : Card
    {
        public Heal2Draw1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Heal2Draw1Card";
            AddEffect(new SingleHealEffect("target Heal 2", 2));
            AddEffect(new DrawEffect("draw 1", 1));
            SetImage();
            Description = "Target Heal 2 & draw 1";
            cost = 0;
        }
    }
}