using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk4Chain4Card : Card
    {
        public SingleAtk4Chain4Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk4Chain4Card";
            AddEffect(new SingleAttackEffect("atk 5", 5));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 5", 5));
            AddEffect(new ChainEffect(temp, "chain atk 5", 5));

            SetImage();
            Description = "5 ���ظ� ������. <color=#DDC59D>����</color> : �ݺ��Ѵ�.";
            cost = 1;
        }
    }
}