using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class DiscardAllDraw5Card : Card
    {
        public DiscardAllDraw5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "DiscardAllDraw5Card";
            AddEffect(new DiscardAllEffect("discard all"));
            AddEffect(new DrawEffect("draw 5", 5));
            AddEffect(new RecoveryCostEffect("recover 3", 3));
            SetImage();
            Description = "���� ��� �и� ������ 5�� ��ο�, �ڽ�Ʈ 3 ȸ��";
            cost = 3;
        }
    }
}