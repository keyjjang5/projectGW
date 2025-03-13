using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
public class DamageCalculator
{
    float baseAttackValue;
    public float AttackValue { get; private set; }
    float baseDefenseValue;
    public float DefenseValue { get; private set; }

    public DamageCalculator()
    {
        baseAttackValue = 1;
        baseDefenseValue = 1;

        AttackValue = baseAttackValue;
        DefenseValue = baseDefenseValue;
    }

    public DamageCalculator(float attackvalue, float defensevalue)
    {
        baseAttackValue = attackvalue;
        baseDefenseValue = defensevalue;

        AttackValue = baseAttackValue;
        DefenseValue = baseDefenseValue;
    }

    public float CalcAtkDamage(float inputDamage)
    {
        float returnValue = -1;

        returnValue = inputDamage * AttackValue;

        return returnValue;
    }

    public float CalcHitDamage(float inputDamage)
    {
        float returnValue = -1;

        returnValue = inputDamage * DefenseValue;

        return returnValue;
    }

    public void ChangeAtk(float value)
    {
        AttackValue += value;
    }

    public void InitAtk()
    {
        AttackValue = baseAttackValue;
    }

    public void ChangeDef(float value)
    {
        DefenseValue += value;
    }

    public void InitDef()
    {
        DefenseValue = baseDefenseValue;
    }
}
