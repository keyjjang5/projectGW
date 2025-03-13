using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using GWEffectVer_0_1;

namespace GWCardVer_0_1
{
    [Serializable]
    public class Attack8Shield5Card : Card
    {
        public Attack8Shield5Card() : base()
        {
            fileName = "AttackAndDefense";
            AddEffect(new AttackEffect(8));
            AddEffect(new SelfShieldEffect(5));
            SetImage();
            Description = "atk 8 def 5";
            cost = 1;
        }
        public Attack8Shield5Card(string name) : base(name)
        {
            fileName = "AttackAndDefense";
            AddEffect(new AttackEffect(8));
            AddEffect(new SelfShieldEffect(5));
            SetImage();
            Description = "atk 8 def 5";
            cost = 1;
        }
        public Attack8Shield5Card(PartyMember parent, string name = "default") : base(parent, name)
        {
            fileName = "AttackAndDefense";
            AddEffect(new AttackEffect(8));
            AddEffect(new SelfShieldEffect(5));
            SetImage();
            Description = "atk 8 def 5";
            cost = 1;
        }
    }
}