using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임내에서 살아가는 것(몬스터, 파티원 등)은 이 것을 가진다
public interface ILife
{
    void Hited(float value);
    void Died();
    void Heal(float value);
    void AddShield(float value);
}
