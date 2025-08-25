using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class Attack8Shield5Card : Card
    {
        public Attack8Shield5Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "Attack8Shield5Card";
            AddEffect(new SingleAttackEffect("singleAtk8", 8));
            AddEffect(new PlayerSelfShieldEffect("selfShield5", 5));
            SetImage();
            Description = "대상에게 8 피해를 입힌다. 보호막 5를 얻는다.";
            cost = 1;
        }
    }
}