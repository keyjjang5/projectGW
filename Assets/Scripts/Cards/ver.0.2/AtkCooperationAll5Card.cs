using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class AtkCooperationAll5Card : Card
    {
        public AtkCooperationAll5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "AtkCooperationAll5Card";
            AddEffect(new SingleAttackEffect("atk 10", 10));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new MassAttackEffect("Mass atk 3", 3));
            AddEffect(new ChainEffect(temp, "coop atk 3", 3));
            SetImage();
            Description = "10 ���ظ� ������. <color=#DDC59D>����</color> : ��� ������ 3 ���ظ� ������.";
            cost = 2;
        }
    }
}