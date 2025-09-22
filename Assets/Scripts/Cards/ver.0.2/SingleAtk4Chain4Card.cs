using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk4Chain4Card : Card
    {
        public SingleAtk4Chain4Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk4Chain4Card";
            AddEffect(new SingleAttackEffect("atk 5", 5));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 5", 5));
            AddEffect(new ChainEffect(temp, "chain atk 5", 5));

            SetImage();
            Description = "5 피해를 입힌다. <color=#DDC59D>연쇄</color> : 반복한다.";
            cost = 1;
        }
    }
}