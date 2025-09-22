using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class ColB2Atk7Card : Card
    {
        public ColB2Atk7Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "ColB2Atk7Card";
            AddEffect(new ColB2AttackEffect("Row B2 Atk11", 11));
            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new ColB2AttackEffect("Row B2 Atk3", 3));
            AddEffect(new CooperationEffect(temp, "Row B2 Atk3", 3));
            SetImage();
            Description = "세로 두칸 범위에 11 피해를 입힌다. <color=#36A0FF>협력</color> : 대신 14피해를 입힌다.";
            cost = 2;
        }
    }
}