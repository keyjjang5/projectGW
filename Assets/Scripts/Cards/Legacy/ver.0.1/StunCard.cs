using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class StunCard : Card
    {
        public StunCard() : base()
        {
            fileName = "Test1";
            AddEffect(new Stun(0));
            SetImage();
            Description = "Stun";
            cost = 1;
        }
        public StunCard(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new Stun(0));
            SetImage();
            Description = "Stun";
            cost = 1;
        }
    }
}