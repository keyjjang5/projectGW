using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Atk10Cooperation2Card : Card
    {
        public Atk10Cooperation2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Atk10Chain1Card";
            AddEffect(new SingleAttackEffect("atk 10", 10));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleAttackEffect("target atk 2", 2));
            AddEffect(new CooperationEffect(temp, "coop atk 2", 2));
            SetImage();
            Description = "대상에게 10 피해를 입힌다. [연계] : 피해 2을 입힌다.";
            cost = 1;
        }
    }
}