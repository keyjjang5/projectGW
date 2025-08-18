using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk8SelfHeal5Card : Card
    {
        public SingleAtk8SelfHeal5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk8SelfHeal5Card";
            AddEffect(new SingleAttackEffect("Single Atk 8", 8));
            AddEffect(new PlayerSelfHealEffect("Self Heal 5", 5));
            SetImage();
            Description = "��󿡰� 8 ���ظ� ������. �ڽ��� ü���� 5 ȸ���Ѵ�.";
            cost = 1;
        }
    }
}