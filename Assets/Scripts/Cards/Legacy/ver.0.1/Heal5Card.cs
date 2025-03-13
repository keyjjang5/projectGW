using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class Heal5Card : Card
    {
        public Heal5Card() : base()
        {
            fileName = "Test1";
            AddEffect(new HealEffect(5));
            SetImage();
            Description = "Heal 5";
            cost = 1;
        }
        public Heal5Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new HealEffect(5));
            SetImage();
            Description = "Heal 5";
            cost = 1;
        }
    }
}