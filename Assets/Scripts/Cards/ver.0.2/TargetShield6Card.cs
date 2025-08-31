using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class TargetShield6Card : Card
    {
        public TargetShield6Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "TargetShield6Card";
            AddEffect(new SingleShieldEffect("single Shield 6", 6));
            SetImage();
            Description = "��ȣ�� 6�� ��´�.";
            cost = 1;
        }
    }
}