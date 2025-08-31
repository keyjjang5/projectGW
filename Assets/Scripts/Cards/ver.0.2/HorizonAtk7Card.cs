using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class HorizonAtk7Card : Card
    {
        public HorizonAtk7Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "HorizonAtk7Card";
            AddEffect(new RowLineAttackEffect("Horizon Atk 7", 7));

            SetImage();
            Description = "���� ��ĭ�� 7 ���ظ� ������.";
            cost = 1;
        }
    }
}