using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk10KnockbackCard : Card
    {
        public SingleAtk10KnockbackCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk10KnockbackCard";
            AddEffect(new SingleAttackEffect("Target Atk 10", 10));
            AddEffect(new SingleKnockbackEffect("Target KnockBack", 1));
            SetImage();
            Description = "��󿡰� ���� 10�� ������ �ڷ� �̵���Ų��.";
            cost = 1;
        }
    }
}