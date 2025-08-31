using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class CrossAtk21Card : Card
    {
        public CrossAtk21Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "CrossAtk21Card";
            AddEffect(new CrossAttackEffect("Cross Atk 12", 12));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 1", 1));
            AddEffect(new ChainEffect(temp, "chain atk 1", 1));

            SetImage();
            Description = "십자범위에 12 피해를 입힌다. [연쇄] : 대상에게 1 피해를 입힌다.";
            cost = 2;
        }
    }
}