using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class ColB2Atk6Card : Card
    {
        public ColB2Atk6Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "ColB2Atk6Card";
            AddEffect(new ColB2AttackEffect("Row B2 Atk6", 6));
            SetImage();
            Description = "���� ��ĭ ������ 6 ���ظ� ������.";
            cost = 1;
        }
    }
}