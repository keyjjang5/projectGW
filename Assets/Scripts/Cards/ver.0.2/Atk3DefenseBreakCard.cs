using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Atk3DefenseBreakCard : Card
    {
        public Atk3DefenseBreakCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Atk3DefenseBreakCard";
            AddEffect(new SingleAttackEffect("single atk 3", 3));
            AddEffect(new SingleDefenseBreakEffect("single Db 2", 50));
            SetImage();
            Description = "Target Atk 3 & Db";
            cost = 1;
        }
    }
}