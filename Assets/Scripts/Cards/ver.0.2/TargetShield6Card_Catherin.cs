using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class TargetShield6Card_Catherin : Card
    {
        public TargetShield6Card_Catherin(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "TargetShield6Card_Catherin";
            AddEffect(new SingleShieldEffect("single Shield 6", 6));
            SetImage();
            Description = "��ȣ�� 6�� ��´�.";
            cost = 1;
        }
    }
}