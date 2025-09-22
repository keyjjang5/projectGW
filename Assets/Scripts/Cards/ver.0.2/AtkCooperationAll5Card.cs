using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class AtkCooperationAll5Card : Card
    {
        public AtkCooperationAll5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "AtkCooperationAll5Card";
            AddEffect(new SingleAttackEffect("atk 10", 10));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new MassAttackEffect("Mass atk 3", 3));
            AddEffect(new ChainEffect(temp, "coop atk 3", 3));
            SetImage();
            Description = "10 피해를 입힌다. <color=#DDC59D>연쇄</color> : 모든 적에게 3 피해를 입힌다.";
            cost = 2;
        }
    }
}