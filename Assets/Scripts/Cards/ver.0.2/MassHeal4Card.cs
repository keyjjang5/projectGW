using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassHeal4Card : Card
    {
        public MassHeal4Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassHeal4Card";
            AddEffect(new MassHealEffect("Mass Heal 4", 4));
            SetImage();
            Description = "�Ʊ� ��ü�� 4 ȸ����Ų��.";
            cost = 1;
        }
    }
}