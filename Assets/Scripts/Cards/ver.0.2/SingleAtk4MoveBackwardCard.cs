using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk4MoveBackwardCard : Card
    {
        public SingleAtk4MoveBackwardCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk4MoveBackwardCard";
            AddEffect(new SingleAttackEffect("Target Atk 4", 4));
            AddEffect(new SingleKnockbackEffect("Target MoveBackward", 1));
            SetImage();
            Description = "��󿡰� ���� 4�� ������ �ڷ� �̵���Ų��.";
            cost = 1;
        }
    }
}