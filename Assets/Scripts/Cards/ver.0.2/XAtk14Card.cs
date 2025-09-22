using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class XAtk14Card : Card
    {
        public XAtk14Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "XAtk14Card";
            AddEffect(new XAttackEffect("X Atk 9", 9));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new XAttackEffect("chain x atk 3", 3));
            AddEffect(new ChainEffect(temp, "chain atk 3", 3));

            SetImage();
            Description = "X������ 9 ���ظ� ������. <color=#DDC59D>����</color> : ���ذ� 3 �þ��.";
            cost = 2;
        }
    }
}