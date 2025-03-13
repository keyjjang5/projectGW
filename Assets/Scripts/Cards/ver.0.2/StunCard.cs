using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class StunCard : Card
    {
        public StunCard(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "StunCard";
            AddEffect(new SingleStunEffect("single stun 1", 1));
            SetImage();
            Description = "Stun 1";
            cost = 1;
        }
    }
}