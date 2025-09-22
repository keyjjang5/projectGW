using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class AtkRow9Isolation6Card : Card
    {
        public AtkRow9Isolation6Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "AtkRow9Isolation6Card";
            AddEffect(new ColLineAttackEffect("Col atk 6", 6));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("target atk 9", 9));
            AddEffect(new IsolationEffect(temp, "Isolation atk 9", 9));
            SetImage();
            Description = "���� 3ĭ�� 6 ���ظ� ������. <color=#F33534>��</color> : ��ĭ�� ���� 9�� ������.";
            cost = 2;
        }
    }
}