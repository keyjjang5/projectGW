using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class CrossAtk20Card : Card
    {
        public CrossAtk20Card() : base()
        {
            fileName = "Test1";
            AddEffect(new CrossAttackEffect(20));
            SetImage();
            Description = "Cross 20";
            cost = 2;
        }
        public CrossAtk20Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new CrossAttackEffect(20));
            SetImage();
            Description = "Cross 20";
            cost = 2;
        }
    }
}