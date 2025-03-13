using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class SuisideEffect : BattleEffect
    {
        public SuisideEffect() : base()
        {

        }

        override public void Active()
        {
            user.GetCharacter().Hited(9999);
        }
    }
}