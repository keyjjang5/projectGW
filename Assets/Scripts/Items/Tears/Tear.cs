using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using GWItemVer_0_1;

[Serializable]
public class Tear : Item
{
    //public string id;
    public Tear(string name = "default") : base(name)
    {
        fileName = "TearTest";
        id = "C_004";

        SetSprite();
    }

    // ���ʸ� ������ �� ����
    override public void TurnStart()
    {

    }

    // ���ʸ� ���� �� �� ����
    override public void TurnEnd()
    {
        
    }

    // ���� ����
    override public void Use()
    {
        
    }

    // ���� ����
    override public bool Use(GameObject target)
    {
        Debug.Log("������ ��� �� �� �����ϴ�");
        return false;
    }
}
