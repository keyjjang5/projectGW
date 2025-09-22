using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// ī�� ����
namespace GWCardVer_0_2
{
    [Serializable]
    public class Heal3Card : Card
    {
        public Heal3Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Heal3Card";
            AddEffect(new SingleHealEffect("target Heal 3", 3));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new DrawEffect("Draw 1", 1));
            AddEffect(new CooperationEffect(temp, "Cooperation Draw 1", 1));

            SetImage();
            Description = "3 ȸ����Ų��. <color=#36A0FF>����</color> : 1���� �̴´�.";
            cost = 0;
        }
    }
}