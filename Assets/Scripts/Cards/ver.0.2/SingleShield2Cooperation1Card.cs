using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleShield2Cooperation1Card : Card
    {
        public SingleShield2Cooperation1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleShield2Cooperation1Card";
            AddEffect(new SingleShieldEffect("target shield 8", 8));
            SetImage();
            Description = "��ȣ�� 8�� ��´�.";
            cost = 1;
        }
    }
}