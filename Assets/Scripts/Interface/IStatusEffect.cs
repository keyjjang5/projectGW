using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ӳ����� �����̻�(����, ����� ��)�� ������ ����� �̰��� ������.
public interface IStatusEffect
{
    void AddStatusEffect(StatusEffect effect);

    // �����̻��� ���ӽð��� 0�� �Ǹ� ����Ǵ� �Լ�
    void Duration0StatusEffect();
}
