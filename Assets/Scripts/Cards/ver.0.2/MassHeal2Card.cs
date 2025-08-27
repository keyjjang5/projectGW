using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassHeal2Card : Card
    {
        public MassHeal2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassHeal2Card";
            AddEffect(new MassHealEffect("Mass Heal 2", 2));
            SetImage();
            Description = "�Ʊ� ��ü�� 2 ȸ����Ų��.";
            cost = 1;
        }
    }
}