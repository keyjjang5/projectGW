using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class Atk10Isolation4Card : Card
    {
        public Atk10Isolation4Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Atk10Chain1Card";
            AddEffect(new SingleAttackEffect("atk 10", 10));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("target atk 4", 4));
            AddEffect(new IsolationEffect(temp, "Isolation atk 4", 4));
            SetImage();
            Description = "��󿡰� 10 ���ظ� ������. [��] : ���� 4�� ������.";
            cost = 1;
        }
    }
}