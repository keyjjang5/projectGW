using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk11Card : Card
    {
        public SingleAtk11Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk11Card";
            AddEffect(new SingleAttackEffect("single atk 7", 7));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("Isolation atk 5", 5));
            AddEffect(new IsolationEffect(temp, "Isolation atk 5", 5));

            SetImage();
            Description = "7 ���ظ� ������. <color=#F33534>��</color> : �߰��� 5 ���ظ� ������.";
            cost = 1;
        }
    }
}