using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SelfAtk2Cost1Card : Card
    {
        public SelfAtk2Cost1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SelfAtk2Cost1Card";
            AddEffect(new PlayerSelfAttackEffect("Self Atk2", 2));
            AddEffect(new RecoveryCostEffect("Regenate Cost 1", 1));
            SetImage();
            Description = "자신에게 피해 2, 코스트 1 회복";
            cost = 0;
        }
    }
}