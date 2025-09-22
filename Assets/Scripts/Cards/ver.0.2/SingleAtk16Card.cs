using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleAtk16Card : Card
    {
        public SingleAtk16Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleAtk16Card";
            AddEffect(new SingleAttackEffect("Target Atk 11", 11));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("Isolation atk 11", 11));
            AddEffect(new IsolationEffect(temp, "Isolation atk 11", 11));

            SetImage();
            Description = "11 피해를 입힌다. <color=#F33534>고립</color> : 대신 22의 피해를 입힌다.";
            cost = 2;
        }
    }
}