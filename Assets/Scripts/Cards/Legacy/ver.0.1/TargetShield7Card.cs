using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class TargetShield7Card : Card
    {
        public TargetShield7Card() : base()
        {
            fileName = "Test1";
            AddEffect(new TargetShieldEffect(7));
            SetImage();
            Description = "target shield 7";
            cost = 1;
        }
        public TargetShield7Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new TargetShieldEffect(7));
            SetImage();
            Description = "target shield 7";
            cost = 1;
        }
    }
}