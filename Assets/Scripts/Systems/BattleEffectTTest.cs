using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleEffectTTest
{
    static public T DeepCopy<T>(this T t) where T : BattleEffect, new()
    {
        T battleEffect = new T();
        battleEffect.Initialize(t.BattleEffectName, t.BasePower, t.MaxCooltime);

        return battleEffect;
    }
}
