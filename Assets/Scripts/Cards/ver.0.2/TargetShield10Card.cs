using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class TargetShield10Card : Card
    {
        public TargetShield10Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "TargetShield10Card";
            AddEffect(new SingleShieldEffect("singleShield10", 10));
            SetImage();
            Description = "����� ��ȣ�� 10�� ��´�.";
            cost = 1;
        }
    }
}