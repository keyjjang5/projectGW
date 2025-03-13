using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : BattleEffect, ITurn
{
    public StatusEffectType StatusEffectType;
    public int Duration;

    public StatusEffect(int power) : base()
    {
        BasePower = power;
        Duration = 1;
    }

    public StatusEffect(string name, int power) : base(name)
    {
        BasePower = power;
        Duration = 1;
    }

    public StatusEffect(string name="dafault", int power = 0, int maxCooltime = 0):base(name, power, maxCooltime)
    {
        BasePower = power;
    }

    virtual public StatusEffect DeepCopy_Status()
    {
        StatusEffect statusEffect = new StatusEffect(BattleEffectName, BasePower, MaxCooltime);

        return statusEffect;
    }

    virtual public float Active(float value)
    {
        float returnValue = 0;

        returnValue = value;

        return returnValue;
    }

    public override void Active()
    {
        base.Active();
    }

    virtual public void StartTurn()
    {

    }
    virtual public void EndTurn()
    {
        if (Duration > 0)
        {
            Duration -= 1;
            Debug.Log("turnend duration : " + Duration);
        }
    }

    virtual public void AddEffect()
    {
        Debug.Log("Effect is added : " + BattleEffectName);
    }

    virtual public void RemoveEffect()
    {
        Debug.Log("Effect is removed : " + BattleEffectName);
    }
}
