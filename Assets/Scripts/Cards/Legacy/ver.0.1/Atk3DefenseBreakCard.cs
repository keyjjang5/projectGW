using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class Atk3DefenseBreakCard : Card
    {
        public Atk3DefenseBreakCard() : base()
        {
            fileName = "Test1";
            AddEffect(new AttackEffect(3));
            AddEffect(new DefenseBreak(2));
            SetImage();
            Description = "Atk 3 & DefenseBreak";
            cost = 1;
        }
        public Atk3DefenseBreakCard(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new AttackEffect(3));
            AddEffect(new DefenseBreak(2));
            SetImage();
            Description = "Atk 3 & DefenseBreak";
            cost = 1;
        }
    }
}