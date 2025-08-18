using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SelfAtk2Cost2Card : Card
    {
        public SelfAtk2Cost2Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SelfAtk2Cost2Card";
            AddEffect(new SelfAttackEffect("Self Atk2", 2));
            AddEffect(new RecoveryCostEffect("Regenate Cost 2", 2));
            SetImage();
            Description = "스스로에게 피해 2, 코스트 2회복";
            cost = 0;
        }
    }
}