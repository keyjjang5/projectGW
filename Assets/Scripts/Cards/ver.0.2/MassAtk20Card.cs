using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using GWEffectVer_0_2;

// 카드 예시
namespace GWCardVer_0_2
{
    [Serializable]
    public class MassAtk20Card : Card
    {
        public MassAtk20Card(Character parent, string name = "default") : base(parent, name)
        {
            fileName = "MassAtk20Card";
            AddEffect(new MassAttackEffect("Mass Atk 20", 20));
            SetImage();
            Description = "전체 범위에 20 피해";
            cost = 3;
        }
    }
}