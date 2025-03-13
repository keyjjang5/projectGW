using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace GWEffectVer_0_1
{
    [Serializable]
    public class SelfHealEffect : BattleEffect
    {
        public SelfHealEffect(int power) : base()
        {

        }
        public SelfHealEffect(string name, int power) : base(name)
        {

        }

        public SelfHealEffect(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {

        }

        public override BattleEffect DeepCopy()
        {
            BattleEffect battleEffect = new SelfHealEffect(BattleEffectName, BasePower, MaxCooltime);
            battleEffect.Target = Target;
            battleEffect.Hitbox = Hitbox;
            battleEffect.user = user;

            return battleEffect;
        }

        override public void Active()
        {
            base.Active();
            user.GetCharacter().Heal(BasePower);
        }
    }
}