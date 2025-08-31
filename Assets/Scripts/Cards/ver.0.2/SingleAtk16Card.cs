using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk16Card : Card
    {
        public SingleAtk16Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk16Card";
            AddEffect(new SingleAttackEffect("Target Atk 16", 16));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("Isolation atk 3", 3));
            AddEffect(new IsolationEffect(temp, "Isolation atk 3", 3));

            SetImage();
            Description = "��󿡰� 16 ���ظ� ������. [��] : �߰��� 3���ظ� ������.";
            cost = 2;
        }
    }
}