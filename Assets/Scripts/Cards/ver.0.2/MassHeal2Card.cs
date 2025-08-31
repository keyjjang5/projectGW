using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassHeal2Card : Card
    {
        public MassHeal2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassHeal2Card";
            AddEffect(new MassHealEffect("Mass Heal 5", 2));
            AddEffect(new RecoveryCostEffect("Recover 1", 1));

            SetImage();
            Description = "아군 전체를 5 회복시킨다. 코스트 1을 회복한다.";
            cost = 1;
        }
    }
}