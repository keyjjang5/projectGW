using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class VerticalAtk7Card : Card
    {
        public VerticalAtk7Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "VerticalAtk7Card";
            AddEffect(new ColLineAttackEffect("Vertical Atk 12", 12));

            SetImage();
            Description = "���� ��ĭ�� 12 ���ظ� ������.";
            cost = 2;
        }
    }
}