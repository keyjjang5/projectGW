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
            AddEffect(new ColB2AttackEffect("Row B2 Atk11", 11));
            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new ColB2AttackEffect("Row B2 Atk3", 3));
            AddEffect(new CooperationEffect(temp, "Row B2 Atk3", 3));
            SetImage();
            Description = "���� ��ĭ ������ 11 ���ظ� ������. <color=#36A0FF>����</color> : ��� 14���ظ� ������.";
            cost = 2;
        }
    }
}