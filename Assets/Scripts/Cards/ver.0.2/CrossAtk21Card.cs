using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class CrossAtk21Card : Card
    {
        public CrossAtk21Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "CrossAtk21Card";
            AddEffect(new CrossAttackEffect("Cross Atk 11", 11));

            SetImage();
            Description = "���ڹ����� 11 ���ظ� ������.";
            cost = 2;
        }
    }
}