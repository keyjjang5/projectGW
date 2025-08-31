using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassAtk19Card : Card
    {
        public MassAtk19Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassAtk19Card";
            AddEffect(new MassAttackEffect("Mass Atk 19", 19));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 1", 1));
            AddEffect(new ChainEffect(temp, "chain atk 1", 1));

            SetImage();
            Description = "��ü ������ 19 ���ظ� ������. [����] : ��󿡰� 1 ���ظ� ������.";
            cost = 3;
        }
    }
}