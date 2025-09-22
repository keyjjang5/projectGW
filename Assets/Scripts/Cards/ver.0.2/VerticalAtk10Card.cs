using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class VerticalAtk10Card : Card
    {
        public VerticalAtk10Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "VerticalAtk10Card";
            AddEffect(new SingleAttackEffect("Vertical Atk 7", 7));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 3", 3));
            AddEffect(new ChainEffect(temp, "chain atk 3", 3));

            SetImage();
            Description = "7 피해를 입힌다. <color=#DDC59D>연쇄</color> : 연쇄만큼 3 피해 추가";
            cost = 1;
        }
    }
}