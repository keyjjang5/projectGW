using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class WitchSkill
{
    string name;
    SkillType skillType;
    int maxCoolTime;
    int nowCoolTime;
    int startCoolTime;
    bool isUsed;
    public bool IsUsed { get { return isUsed; } }

    public Sprite sprite;
    string imageRoot = "Image/Actives/";
    public string fileName;

    public WitchSkill(string name = "default", SkillType skillType = SkillType.Active, int maxCoolTime = 1, int startCoolTime = 0)
    {
        isUsed = false;

        this.skillType = skillType;
        this.maxCoolTime = maxCoolTime;
        this.startCoolTime = startCoolTime;

        fileName = "SkillTest";
        SetSprite();
    }

    // 전투 시작할때 실행
    public void BattleStart()
    {
        nowCoolTime = this.startCoolTime;

        isUsed = nowCoolTime <= 0 ? false : true;
    }
    
    // 차례를 시작할 때 실행
    public void TurnStart()
    {

    }

    // 차례를 종료 할 때 실행
    public void TurnEnd()
    {
        reduceCoolTime(1);
    }

    // 사용시 실행
    public void Use()
    {
        nowCoolTime = maxCoolTime;
        isUsed = true;
    }

    // 사용시 실행
    public void Use(GameObject target)
    {
        nowCoolTime = maxCoolTime;
        isUsed = true;

        Debug.Log("WitchSkill Use : " + name + " target > " + target.name);
    }

    // 쿨타임 감소 함수
    void reduceCoolTime(int num)
    {
        nowCoolTime -= num;

        if (nowCoolTime <= 0)
        {
            nowCoolTime = 0;
            isUsed = false;
        }
    }

    public void SetSprite()
    {
        sprite = Resources.Load<Sprite>(imageRoot + fileName);
    }
}
