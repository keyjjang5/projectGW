using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ӳ����� ��ư��� ��(����, ��Ƽ�� ��)�� �� ���� ������
public interface ILife
{
    void Hited(float value);
    void Died();
    void Heal(float value);
    void AddShield(float value);
}
