using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class Recovery3CostDraw2Card : Card
    {
        public Recovery3CostDraw2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Recovery3CostDraw2Card";
            AddEffect(new RecoveryCostEffect("Recovery Cost 2", 2));
            SetImage();
            Description = "2 �ڽ�Ʈ ȸ���Ѵ�.";
            cost = 1;
        }
    }
}