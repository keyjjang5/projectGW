using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class RowR2A8Card : Card
    {
        public RowR2A8Card() : base()
        {
            fileName = "Test1";
            AddEffect(new RowR2AttackEffect(8));
            SetImage();
            Description = "RowR2 atk8";
            cost = 1;
        }
        public RowR2A8Card(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new RowR2AttackEffect(8));
            SetImage();
            Description = "RowR2 atk8";
            cost = 1;
        }
    }
}