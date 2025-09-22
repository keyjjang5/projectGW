using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class AtkRow9Isolation6Card : Card
    {
        public AtkRow9Isolation6Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "AtkRow9Isolation6Card";
            AddEffect(new ColLineAttackEffect("Col atk 6", 6));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("target atk 9", 9));
            AddEffect(new IsolationEffect(temp, "Isolation atk 9", 9));
            SetImage();
            Description = "세로 3칸에 6 피해를 입힌다. <color=#F33534>고립</color> : 한칸에 피해 9을 입힌다.";
            cost = 2;
        }
    }
}