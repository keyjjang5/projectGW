using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk7KnockbackCard : Card
    {
        public SingleAtk7KnockbackCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk7KnockbackCard";
            AddEffect(new SingleAttackEffect("Target Atk 8", 8));
            AddEffect(new SingleKnockbackEffect("Target KnockBack", 1));
            SetImage();
            Description = "���� 8�� ������ �ڷ� �̵���Ų��.";
            cost = 1;
        }
    }
}