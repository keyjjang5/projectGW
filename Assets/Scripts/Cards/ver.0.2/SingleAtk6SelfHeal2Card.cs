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
            AddEffect(new SingleAttackEffect("Single Atk 6", 6));
            AddEffect(new PlayerSelfHealEffect("Self Heal 2", 2));
            SetImage();
            Description = "��󿡰� 6 ���ظ� ������. �ڽ��� ü���� 2 ȸ���Ѵ�.";
            cost = 1;
        }
    }
}