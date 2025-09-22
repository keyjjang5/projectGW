using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassShield18Card : Card
    {
        public MassShield18Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassShield18Card";
            AddEffect(new MassShieldEffect("Mass Shield 18", 14));
            SetImage();
            Description = "��ü���� ��ȣ�� 14 �ο��Ѵ�.";
            cost = 2;
        }
    }
}