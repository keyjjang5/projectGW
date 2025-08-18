using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Heal3Draw1Card : Card
    {
        public Heal3Draw1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Heal3Draw1Card";
            AddEffect(new SingleHealEffect("target Heal 3", 3));
            AddEffect(new DrawEffect("draw 1", 1));
            SetImage();
            Description = "대상을 3 회복 시키고 1 장 뽑는다.";
            cost = 0;
        }
    }
}