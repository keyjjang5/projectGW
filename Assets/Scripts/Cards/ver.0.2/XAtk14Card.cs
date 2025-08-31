using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class XAtk14Card : Card
    {
        public XAtk14Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "XAtk14Card";
            AddEffect(new XAttackEffect("X Atk 14", 14));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("chain atk 1", 1));
            AddEffect(new ChainEffect(temp, "chain atk 1", 1));

            SetImage();
            Description = "X범위에 14 피해를 입힌다. <color=#DDC59D>연쇄</color> : 1 피해를 입힌다.";
            cost = 2;
        }
    }
}