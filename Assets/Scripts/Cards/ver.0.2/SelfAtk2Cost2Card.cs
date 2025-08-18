using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SelfAtk2Cost2Card : Card
    {
        public SelfAtk2Cost2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SelfAtk2Cost2Card";
            AddEffect(new SelfAttackEffect("Self Atk2", 2));
            AddEffect(new RecoveryCostEffect("Regenate Cost 2", 2));
            SetImage();
            Description = "�����ο��� ���� 2, �ڽ�Ʈ 2ȸ��";
            cost = 0;
        }
    }
}