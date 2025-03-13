using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class MassHeal3Card : Card
    {
        public MassHeal3Card() : base()
        {
            fileName = "Test1";
            AddEffect(new MassHealEffect(3));
            SetImage();
            Description = "Mass Heal 3";
            cost = 1;
        }
        public MassHeal3Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new MassHealEffect(3));
            SetImage();
            Description = "Mass Heal 3";
            cost = 1;
        }
    }
}