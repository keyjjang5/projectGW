using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassShield8Card : Card
    {
        public MassShield8Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassShield8Card";
            AddEffect(new MassShieldEffect("Mass Shield 5", 5));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new MassShieldEffect("Cooperation Mass Shield 5", 5));
            AddEffect(new CooperationEffect(temp, "Cooperation Mass Shield 5", 5));

            SetImage();
            Description = "��ü���� ��ȣ�� 5 �ο��Ѵ�. <color=#36A0FF>����</color> : ��� 10 �ο��Ѵ�.";
            cost = 2;
        }
    }
}