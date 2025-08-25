using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class Attack8Shield5Card : Card
    {
        public Attack8Shield5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Attack8Shield5Card";
            AddEffect(new SingleAttackEffect("singleAtk8", 8));
            AddEffect(new PlayerSelfShieldEffect("selfShield5", 5));
            SetImage();
            Description = "��󿡰� 8 ���ظ� ������. ��ȣ�� 5�� ��´�.";
            cost = 1;
        }
    }
}