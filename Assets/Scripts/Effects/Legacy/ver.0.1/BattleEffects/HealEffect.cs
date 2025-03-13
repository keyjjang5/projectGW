using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class HealEffect : BattleEffect
    {
        public HealEffect(int power) : base()
        {

        }
        public HealEffect(string name, int power) : base(name)
        {

        }
        public HealEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {

        }

        override public void Active()
        {
            Hitbox.BroadcastMessage("Heal", new HealStruct(HealType.Single, BasePower));
        }
    }
}