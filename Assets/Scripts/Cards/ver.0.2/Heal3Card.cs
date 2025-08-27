using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Heal3Card : Card
    {
        public Heal3Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Heal3Card";
            AddEffect(new SingleHealEffect("target Heal 3", 3));
            SetImage();
            Description = "대상을 3 회복시킨다.";
            cost = 1;
        }
    }
}