using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class DrawEffect : BattleEffect
    {
        public int power;

        public DrawEffect(int power) : base()
        {
            this.power = power;
        }
        public DrawEffect(string name, int power) : base(name)
        {
            this.power = power;
        }

        override public void Active()
        {
            for (int i = 0; i < power; i++)
                DeckSystem.Instance.Draw();
        }
    }
}