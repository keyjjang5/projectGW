using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class VerticalAtk10Card : Card
    {
        public VerticalAtk10Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "VerticalAtk10Card";
            AddEffect(new ColLineAttackEffect("Vertical Atk 10", 10));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 1", 1));
            AddEffect(new ChainEffect(temp, "chain atk 1", 1));

            SetImage();
            Description = "���� ��ĭ�� 10 ���ظ� ������. <color=#DDC59D>����</color> : 1 ���ظ� ������.";
            cost = 2;
        }
    }
}