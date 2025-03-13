using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class Random3Atk6Card : Card
    {
        public Random3Atk6Card() : base()
        {
            fileName = "Test1";
            AddEffect(new RandomAttackEffect(6));
            AddEffect(new RandomAttackEffect(6));
            AddEffect(new RandomAttackEffect(6));
            SetImage();
            Description = "Random 3 Atk 6";
            cost = 1;
        }
        public Random3Atk6Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new RandomAttackEffect(6));
            AddEffect(new RandomAttackEffect(6));
            AddEffect(new RandomAttackEffect(6));
            SetImage();
            Description = "Random 3 Atk 6";
            cost = 1;
        }
    }
}