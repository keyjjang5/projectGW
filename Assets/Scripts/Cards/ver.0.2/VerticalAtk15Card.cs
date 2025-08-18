using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class VerticalAtk15Card : Card
    {
        public VerticalAtk15Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "VerticalAtk15Card";
            AddEffect(new ColLineAttackEffect("Vertical Atk 15", 15));
            SetImage();
            Description = "���ι����� 15 ����";
            cost = 2;
        }
    }
}