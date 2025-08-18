using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassAtk20Card : Card
    {
        public MassAtk20Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassAtk20Card";
            AddEffect(new MassAttackEffect("Mass Atk 20", 20));
            SetImage();
            Description = "��ü ������ 20 ����";
            cost = 3;
        }
    }
}