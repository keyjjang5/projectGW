using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class KnockBackCard : Card
    {
        public KnockBackCard() : base()
        {
            fileName = "KnockBack";
            AddEffect(new KnockbackEffect());
            SetImage();
            Description = "KnockBack 1";
            cost = 1;
        }
        public KnockBackCard(string name) : base(name)
        {
            fileName = "Test2";
            AddEffect(new KnockbackEffect());
            SetImage();
            Description = "KnockBack 1";
            cost = 1;
        }
    }
}