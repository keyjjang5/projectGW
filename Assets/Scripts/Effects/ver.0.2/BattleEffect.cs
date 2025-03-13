using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
public class BattleEffect
{
    public string BattleEffectName;
    public GameObject Hitbox;
    public Character Target;
    public IUser user;

    public int MaxCooltime;
    public int NowCooltime;

    public int BasePower;
    public int NowPower;

    public BattleEffect()
    {
        BattleEffectName = "default";

        MaxCooltime = 0;
        NowCooltime = MaxCooltime;

        BasePower = 0;
    }
    public BattleEffect(string name)
    {
        BattleEffectName = name;

        MaxCooltime = 0;
        NowCooltime = MaxCooltime;

        BasePower = 0;
    }

    public BattleEffect(string name="default", int power = 0, int maxCooltime = 0)
    {
        BattleEffectName = name;

        this.BasePower = power;
        NowPower = BasePower;

        MaxCooltime = maxCooltime;
        NowCooltime = MaxCooltime;
    }

    public void Initialize(string name = "default", int power = 0, int maxCooltime = 0)
    {
        BattleEffectName = name;

        this.BasePower = power;

        MaxCooltime = maxCooltime;
        NowCooltime = MaxCooltime;
    }

    virtual public void Active()
    {
        if (MaxCooltime != NowCooltime)
        {
            Debug.Log("Cooltime Activating");
            return;
        }

        //Debug.Log("Basic BattleEffect");
        //target.BroadcastMessage("Hited", 5.0f);

        // Debug.Log("BattleEffect Activate");
        NowCooltime = 0;
    }
    public void SetHitbox(GameObject target)
    {
        this.Hitbox = target;
    }

    public void SetTarget(Character target)
    {
        this.Target = target;
    }
    
    public void SetUser(IUser user)
    {
        this.user = user;
    }

    public void ReduceCooltime(int num)
    {
        NowCooltime += num;

        if (NowCooltime > MaxCooltime)
            NowCooltime = MaxCooltime;

        // Debug.Log("Now cooltime is " + (MaxCooltime - NowCooltime));
    }

    public void IncreaseCooltime(int num)
    {
        NowCooltime -= num;

        if (NowCooltime < 0)
            NowCooltime = 0;
    }

    public bool IsActive()
    {
        return NowCooltime == MaxCooltime ? true : false;
    }

    virtual public BattleEffect DeepCopy()
    {
        BattleEffect battleEffect = new BattleEffect(BattleEffectName, BasePower, MaxCooltime);

        return battleEffect;
    }
}
