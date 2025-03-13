using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임내에서 상태이상(버프, 디버프 등)을 가지는 존재는 이것을 가진다.
public interface IStatusEffect
{
    void AddStatusEffect(StatusEffect effect);

    // 상태이상의 지속시간이 0이 되면 실행되는 함수
    void Duration0StatusEffect();
}
