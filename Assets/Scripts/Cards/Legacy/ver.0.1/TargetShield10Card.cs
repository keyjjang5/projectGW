using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class TargetShield10Card : Card
    {
        public TargetShield10Card() : base()
        {
            fileName = "Test1";
            AddEffect(new TargetShieldEffect(10));
            SetImage();
            Description = "Shield 10";
            cost = 1;
        }
        public TargetShield10Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new TargetShieldEffect(10));
            SetImage();
            Description = "Shield 10";
            cost = 1;
        }
    }
}