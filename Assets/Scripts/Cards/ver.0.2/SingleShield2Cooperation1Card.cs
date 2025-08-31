using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleShield2Cooperation1Card : Card
    {
        public SingleShield2Cooperation1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleShield2Cooperation1Card";
            AddEffect(new SingleShieldEffect("target shield 2", 2));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleShieldEffect("target shield 1", 1));
            AddEffect(new CooperationEffect(temp, "coop shield 1", 1));

            SetImage();
            Description = "����� ��ȣ�� 2�� ��´�. [����] : �߰��� 1�� ��´�.";
            cost = 0;
        }
    }
}