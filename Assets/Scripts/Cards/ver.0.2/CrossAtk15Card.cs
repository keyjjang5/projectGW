using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class CrossAtk15Card : Card
    {
        public CrossAtk15Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "CrossAtk15Card";
            AddEffect(new CrossAttackEffect("Cross Atk 15", 15));
            SetImage();
            Description = "���ڹ����� 15 ����";
            cost = 3;
        }
    }
}