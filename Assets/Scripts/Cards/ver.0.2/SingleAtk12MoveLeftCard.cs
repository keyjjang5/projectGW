using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk12MoveLeftCard : Card
    {
        public SingleAtk12MoveLeftCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk12MoveLeftCard";
            AddEffect(new SingleAttackEffect("Target Atk 12", 12));
            AddEffect(new SingleMoveLeftEffect("Target MoveLeft", 1));
            SetImage();
            Description = "��󿡰� ���� 12�� ������ �������� �̵���Ų��.";
            cost = 1;
        }
    }
}