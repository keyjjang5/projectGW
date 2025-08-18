using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class ColB2Atk10Card : Card
    {
        public ColB2Atk10Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "ColB2Atk10Card";
            AddEffect(new ColB2AttackEffect("Row B2 Atk10", 10));
            SetImage();
            Description = "��� �������� 1*2 ������ 10 ���ظ� ������.";
            cost = 1;
        }
    }
}