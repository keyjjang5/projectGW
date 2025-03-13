using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class Heal2Draw1Card : Card
    {
        public Heal2Draw1Card() : base()
        {
            fileName = "Test1";
            AddEffect(new HealEffect(2));
            AddEffect(new DrawEffect(1));
            SetImage();
            Description = "Heal 2 & Draw 1";
            cost = 0;
        }
        public Heal2Draw1Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new HealEffect(2));
            AddEffect(new DrawEffect(1));
            SetImage();
            Description = "Heal 2 & draw 1";
            cost = 0;
        }
    }
}