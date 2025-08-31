using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.Events;

[Serializable]
public class Character : ILife, IStatusEffect, IUser, ITurn
{
    public string Name;
    public string id;
    public int Pos;
    public int time;

    public float MaxHp;
    public float NowHp;
    public float Shield;
    public bool IsDead;
    public UnityEvent Die;

    public List<StatusEffect> StatusEffects;

    public DamageCalculator DamageCalculator;
    public float attackValue;
    public float defenseValue;

    public Vector3 scale;

    public Character(string name = "default", float maxhp = 100, int pos = 0)
    {
        Name = name;
        id = "C_000";
        Pos = pos;
        time = 0;

        MaxHp = maxhp;
        NowHp = MaxHp;
        Shield = 0;
        IsDead = false;

        if (Die == null)
            Die = new UnityEvent();

        if (StatusEffects == null)
            StatusEffects = new List<StatusEffect>();

        DamageCalculator = new DamageCalculator();
        attackValue = 1;
        defenseValue = 1;

        scale = new Vector3(1, 1, 1);
    }

    public void Initalize()
    {
        id = "C_000";
        time = 0;

        NowHp = MaxHp;
        Shield = 0;
        IsDead = false;

        if (Die == null)
            Die = new UnityEvent();

        if (StatusEffects == null)
            StatusEffects = new List<StatusEffect>();

        DamageCalculator = new DamageCalculator();
        attackValue = 1;
        defenseValue = 1;

        scale = new Vector3(1, 1, 1);
    }

    public virtual void Hited(float value)
    {
        value = DamageCalculator.CalcHitDamage(value);
        if (NowHp <= 0)
            return;

        if (Shield >= value)
            Shield -= value;
        else
        {
            Shield -= value;
            value = Math.Abs(Shield);
            Shield = 0;
            NowHp -= value;
        }

        if (NowHp <= 0)
            Died();

        Debug.Log("hp : " + NowHp + "shiled : " + Shield);
            //Shield -= value;
            //if (Shield > 0)
            //    return;
            //else
            //    NowHp += Shield;
            //Shield = 0;
    }

    public void Heal(float value)
    {
        NowHp += value;

        if (NowHp > MaxHp)
            NowHp = MaxHp;

        Debug.Log("hp : " + NowHp);
    }

    public void AddShield(float value)
    {
        Shield += value; 
    }

    public virtual void Died()
    {
        IsDead = true;
        Die.Invoke();
    }

    public void AddStatusEffect(StatusEffect effect)
    {
        effect.SetTarget(GetCharacter());
        effect = effect.DeepCopy_Status();
        Debug.Log("effect : " + effect.BattleEffectName + effect.BasePower);
        StatusEffects.Add(effect);

        effect.AddEffect();

        //foreach (var statusEffect in StatusEffects)
        //{
        //    Debug.Log("statusEffect : " + statusEffect.StatusEffectType);
        //}
        //GameLoopSystem.Instance.EndUserTurn.AddListener(effect.EndTurn);

        //있으면 지우고 추가한다. 있는지 없는지 확인할 수단이 없으므로 일단 지움
        //GameLoopSystem.Instance.EndUserTurn.RemoveListener(Duration0StatusEffect);
        //GameLoopSystem.Instance.EndUserTurn.AddListener(Duration0StatusEffect);

        Debug.Log("add status effect" + Name);
    }

    public void Duration0StatusEffect()
    {
        for (int i = 0; i < StatusEffects.Count; i++)
        {
            if (StatusEffects[i].Duration <= 0)
            {
                StatusEffects[i].RemoveEffect();

                //GameLoopSystem.Instance.EndUserTurn.RemoveListener(StatusEffects[i].EndTurn);
                StatusEffects.RemoveAt(i);
                i--;

                Debug.Log("remove status effect");
            }
        }
    }

    public Character GetCharacter()
    {
        return this;
    }

    virtual public void StartTurn()
    {
        time += 1;
        Shield = 0;
    }
    virtual public void EndTurn()
    {
        foreach (var statusEffect in StatusEffects)
        {
            Debug.Log("statusEffect : " + statusEffect.StatusEffectType);

            statusEffect.EndTurn();
        }
        Duration0StatusEffect();
    }

    public Vector3 GetScale()
    {
        return scale;
    }

    public virtual Character DeepCopy()
    {
        Character copy = new Character();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "C_000";
        copy.Pos = Pos;
        copy.time = time;
        copy.MaxHp = MaxHp;
        copy.NowHp = NowHp;
        copy.IsDead = IsDead;

        copy.Die = Die;
        copy.StatusEffects = StatusEffects;
        copy.DamageCalculator = DamageCalculator;
        copy.attackValue = attackValue;
        copy.defenseValue = defenseValue;

        copy.scale = scale;

        return copy;
    }
}
