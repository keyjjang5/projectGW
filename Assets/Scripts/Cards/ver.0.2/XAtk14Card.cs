using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class XAtk14Card : Card
    {
        public XAtk14Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "XAtk14Card";
            AddEffect(new XAttackEffect("X Atk 14", 14));
            SetImage();
            Description = "X������ 14 ����";
            cost = 2;
        }
    }
}