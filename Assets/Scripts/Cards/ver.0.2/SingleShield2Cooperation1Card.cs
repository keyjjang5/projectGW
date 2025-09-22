using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class SingleShield2Cooperation1Card : Card
    {
        public SingleShield2Cooperation1Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "SingleShield2Cooperation1Card";
            AddEffect(new SingleShieldEffect("target shield 8", 8));
            SetImage();
            Description = "보호막 8를 얻는다.";
            cost = 1;
        }
    }
}