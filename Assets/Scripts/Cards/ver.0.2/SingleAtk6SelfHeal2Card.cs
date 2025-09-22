using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk6SelfHeal2Card : Card
    {
        public SingleAtk6SelfHeal2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk6SelfHeal2Card";
            AddEffect(new SingleAttackEffect("Single Atk 14", 14));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new PlayerSelfMassShieldEffect("Mass Shield 4", 4));
            AddEffect(new CooperationEffect(temp, "Mass Shield 4", 4));

            SetImage();
            Description = "14 ���ظ� ������. <color=#36A0FF>����</color> : �Ʊ� ��ü���� ��ȣ�� 4";
            cost = 2;
        }
    }
}