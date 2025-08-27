using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk11Card : Card
    {
        public SingleAtk11Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk11Card";
            AddEffect(new SingleAttackEffect("single atk 11", 11));
            SetImage();
            Description = "��󿡰� ���� 11�� ������.";
            cost = 1;
        }
    }
}