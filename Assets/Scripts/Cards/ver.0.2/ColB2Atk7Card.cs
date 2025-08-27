using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class ColB2Atk7Card : Card
    {
        public ColB2Atk7Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "ColB2Atk7Card";
            AddEffect(new ColB2AttackEffect("Row B2 Atk7", 7));
            SetImage();
            Description = "��� �������� 1*2 ������ 7 ���ظ� ������.";
            cost = 1;
        }
    }
}