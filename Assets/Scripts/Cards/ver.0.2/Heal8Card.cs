using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class Heal8Card : Card
    {
        public Heal8Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Heal8Card";
            AddEffect(new SingleHealEffect("target Heal 8", 8));
            SetImage();
            Description = "����� 8 ȸ����Ų��.";
            cost = 1;
        }
    }
}