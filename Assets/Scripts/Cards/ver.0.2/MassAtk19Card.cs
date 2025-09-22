using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassAtk19Card : Card
    {
        public MassAtk19Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassAtk19Card";
            AddEffect(new MassAttackEffect("Mass Atk 5", 5));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new MassAttackEffect("Mass Atk 5", 5));
            AddEffect(new ChainEffect(temp, "Mass Atk 5", 5));

            SetImage();
            Description = "전체 범위에 5 피해를 입힌다. <color=#DDC59D>연쇄</color> : 반복한다";
            cost = 3;
        }
    }
}