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
            AddEffect(new SingleAttackEffect("Vertical Atk 7", 7));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 3", 3));
            AddEffect(new ChainEffect(temp, "chain atk 3", 3));

            SetImage();
            Description = "7 ���ظ� ������. <color=#DDC59D>����</color> : ���⸸ŭ 3 ���� �߰�";
            cost = 1;
        }
    }
}