using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk11Card : Card
    {
        public SingleAtk11Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk11Card";
            AddEffect(new SingleAttackEffect("single atk 11", 11));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("Isolation atk 2", 2));
            AddEffect(new IsolationEffect(temp, "Isolation atk 2", 2));

            SetImage();
            Description = "대상에게 11 피해를 입힌다. [고립] : 대상에게 2 피해를 입힌다.";
            cost = 1;
        }
    }
}