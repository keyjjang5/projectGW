using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class ColB2A15Card : Card
    {
        public ColB2A15Card() : base()
        {
            fileName = "Test1";
            AddEffect(new ColB2AttackEffect(15));
            SetImage();
            Description = "Col b2 Atk 15";
            cost = 2;
        }
        public ColB2A15Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new ColB2AttackEffect(15));
            SetImage();
            Description = "Col b2 Atk 15";
            cost = 2;
        }
    }
}