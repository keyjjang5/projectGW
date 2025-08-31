using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Atk10Chain1Card : Card
    {
        public Atk10Chain1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Atk10Chain1Card";
            AddEffect(new SingleAttackEffect("atk 10", 10));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 1", 1));
            AddEffect(new ChainEffect(temp, "chain atk 1", 1));

            SetImage();
            Description = "대상에게 10 피해를 입힌다. [연쇄] : 피해 1을 입힌다.";
            cost = 1;
        }
    }
}