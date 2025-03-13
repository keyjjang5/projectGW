using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class Atk10Card : Card
    {
        public Atk10Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Atk10Card";
            AddEffect(new SingleAttackEffect("cardTest1", 10));
            SetImage();
            Description = "Target Atk 10";
            cost = 1;
        }
    }
}