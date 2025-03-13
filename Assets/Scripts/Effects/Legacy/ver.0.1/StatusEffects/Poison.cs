using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GWEffectVer_0_1
{
    public class Poison : StatusEffect
    {
        public Poison(string name = "default", int power = 0, int maxCooltime = 0) : base(name, power, maxCooltime)
        {
            StatusEffectType = StatusEffectType.Poison;
            Duration = 2;
        }

        public override StatusEffect DeepCopy_Status()
        {
            StatusEffect statusEffect = new Poison(BattleEffectName, BasePower, MaxCooltime);
            statusEffect.SetTarget(Target);


            return statusEffect;
        }

        override public void Active()
        {
            base.Active();
            Hitbox.BroadcastMessage("AddStatusEffect2", new StatusStruct(this, Target.Pos));
            // Debug.Log("Duration = " + Duration);
        }

        override public float Active(float value)
        {
            float returnValue = 0;

            returnValue = BasePower;

            return returnValue;
        }

        override public void EndTurn()
        {
            base.EndTurn();

            Target.Hited(BasePower);
        }
    }
}