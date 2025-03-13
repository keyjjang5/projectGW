using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class Atk7KnockBackCard : Card
    {
        public Atk7KnockBackCard() : base()
        {
            fileName = "Test1";
            AddEffect(new AttackEffect(7));
            AddEffect(new KnockbackEffect());
            SetImage();
            Description = "atk 7 knockback";
            cost = 1;
        }
        public Atk7KnockBackCard(string name) : base(name)
        {
            fileName = "Test1";
            AddEffect(new AttackEffect(7));
            AddEffect(new KnockbackEffect());
            SetImage();
            Description = "atk 7 knockback";
            cost = 1;
        }
    }
}