using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class Atk10Chain1Card : Card
    {
        public Atk10Chain1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Atk10Chain1Card";
            AddEffect(new SingleAttackEffect("atk 10", 10));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 1", 1));
            AddEffect(new ChainEffect(temp, "chain atk 1", 1));

            SetImage();
            Description = "��󿡰� 10 ���ظ� ������. [����] : ���� 1�� ������.";
            cost = 1;
        }
    }
}