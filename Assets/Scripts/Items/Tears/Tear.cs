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

    // 차례를 시작할 때 실행
    override public void TurnStart()
    {

    }

    // 차례를 종료 할 때 실행
    override public void TurnEnd()
    {
        
    }

    // 사용시 실행
    override public void Use()
    {
        
    }

    // 사용시 실행
    override public bool Use(GameObject target)
    {
        Debug.Log("눈물은 사용 할 수 없습니다");
        return false;
    }
}
