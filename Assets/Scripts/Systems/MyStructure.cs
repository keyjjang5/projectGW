using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


[Serializable]
public struct AttackStruct
{
    public AttackType AttackType;
    public int Power;
    public int TargetPos;

    public AttackStruct(AttackType attackType, int power, int targetPos = -1)
    {
        AttackType = attackType;
        Power = power;
        TargetPos = targetPos;
    }
}

public struct ShieldStruct
{
    public ShieldType ShieldType;
    public int Power;
    public int TargetPos;

    public ShieldStruct(ShieldType shieldType, int power, int targetPos = -1)
    {
        ShieldType = shieldType;
        Power = power;
        TargetPos = targetPos;
    }
}

/*
 *  HealType이 percent일 경우 30% = 30의 Power를 가진다.
 */
public struct HealStruct
{
    public HealType HealType;
    public int Power;
    public int TargetPos;

    public HealStruct(HealType healType, int power, int targetPos = -1)
    {
        HealType = healType;
        Power = power;
        TargetPos = targetPos;
    }
}


public struct KnockbackStruct
{
    public int TargetPos;
    public int Power;
    public KnockbackType KnockbackType;

    public KnockbackStruct(KnockbackType knockbackType, int targetPos = -1, int power = 1)
    {
        TargetPos = targetPos;
        Power = power;
        KnockbackType = knockbackType;
    }
}

public struct StatusStruct
{
    public int TargetPos;
    public StatusEffect StatusEffect;
    public AttackType type;

    public StatusStruct(StatusEffect statusEffect, int targetPos = -1, AttackType type = AttackType.Single)
    {
        StatusEffect = statusEffect;
        TargetPos = targetPos;
        this.type = type;
    }
}

public struct AdditionalEffectStruct
{
    public int TargetPos;
    public List<BattleEffect> effects;
    public AdditionalType type;

    public AdditionalEffectStruct(AdditionalType type = AdditionalType.Chain, int targetPos = -1)
    {
        this.type = type;
        TargetPos = targetPos;
        effects = new List<BattleEffect>();
    }
}

public struct RewardStruct
{
    public RewardType rewardType;
    public int value;
    public string id;

    public RewardStruct(RewardType type, int value, string id)
    {
        rewardType = type;
        this.value = value;
        this.id = id;
    }
}

[Serializable]
public class Attack
{
    public string Name;
    public List<BattleEffect> BattleEffects;
    public IconType Type;
    public float Power;
    public float NowPower;

    public int MaxCooltime;
    public int NowCooltime;

    public Attack(IconType iconType, float power, int maxCooltime = 0, string name= "default")
    {
        Name = name;
        Type = iconType;
        Power = power;
        NowPower = Power;
        BattleEffects = new List<BattleEffect>();

        MaxCooltime = maxCooltime;
        NowCooltime = MaxCooltime;
    }

    public void AddBattleEffect(BattleEffect battleEffect)
    {
        BattleEffects.Add(battleEffect);
    }

    public bool Active()
    {
        if (MaxCooltime != NowCooltime)
        {
            Debug.Log("Cooltime Activating");
            return false;
        }

        NowCooltime = 0;
        return true;
    }

    public void ReduceCooltime(int num)
    {
        NowCooltime += num;

        if (NowCooltime > MaxCooltime)
            NowCooltime = MaxCooltime;
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
}