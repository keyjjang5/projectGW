using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class AttackAndDefenseEffect : BattleEffect
    {
        public AttackAndDefenseEffect() : base()
        {

        }
        public AttackAndDefenseEffect(string name) : base(name)
        {

        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("Hited", 8);

            user.GetCharacter().AddShield(5);
        }
    }
}