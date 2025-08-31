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
            AddEffect(new SingleShieldEffect("target shield 2", 2));

            List<BattleEffect> temp = new List<BattleEffect>();
            temp.Add(new SingleShieldEffect("target shield 1", 1));
            AddEffect(new CooperationEffect(temp, "coop shield 1", 1));

            SetImage();
            Description = "대상은 보호막 2를 얻는다. [협력] : 추가로 1을 얻는다.";
            cost = 0;
        }
    }
}