using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Attack5Shield4Card : Card
    {
        public Attack5Shield4Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Attack5Shield4Card";
            AddEffect(new SingleAttackEffect("singleAtk5", 5));
            AddEffect(new PlayerSelfShieldEffect("selfShield4", 4));
            SetImage();
            Description = "대상에게 5 피해를 입힌다. 보호막 4를 얻는다.";
            cost = 1;
        }
    }
}