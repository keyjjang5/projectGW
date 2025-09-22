using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk9MoveForwardCard : Card
    {
        public SingleAtk9MoveForwardCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk9MoveForwardCard";
            AddEffect(new SingleAttackEffect("Target Atk 9", 9));
            AddEffect(new SingleMoveForwardEffect("Target MoveForward", 1));
            SetImage();
            Description = "���� 9�� ������ �������� �̵���Ų��.";
            cost = 1;
        }
    }
}