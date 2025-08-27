using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassAtk19Card : Card
    {
        public MassAtk19Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassAtk19Card";
            AddEffect(new MassAttackEffect("Mass Atk 19", 19));
            SetImage();
            Description = "��ü ������ 19 ����";
            cost = 3;
        }
    }
}