using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class Attack5Shield4Card : Card
    {
        public Attack5Shield4Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Attack5Shield4Card";
            AddEffect(new SingleAttackEffect("singleAtk 7", 7));
            AddEffect(new PlayerSelfShieldEffect("selfShield4", 4));
            SetImage();
            Description = "��󿡰� 7 ���ظ� ������. ��ȣ�� 4�� ��´�.";
            cost = 1;
        }
    }
}