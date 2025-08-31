using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleMoveRightChainCard : Card
    {
        public SingleMoveRightChainCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleMoveRightChainCard";
            AddEffect(new SingleAttackEffect("Atk 5", 5));
            AddEffect(new SingleMoveRightEffect("Move right", 1));
            SetImage();
            Description = "5 ���ظ� ������ ���������� �̵���Ų��.";
            cost = 0;
        }
    }
}