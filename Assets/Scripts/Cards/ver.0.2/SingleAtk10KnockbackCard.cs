using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk12Card : Card
    {
        public SingleAtk12Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk12Card";
            AddEffect(new SingleAttackEffect("cardTest1", 12));
            SetImage();
            Description = "��󿡰� ���� 12�� ������.";
            cost = 1;
        }
    }
}