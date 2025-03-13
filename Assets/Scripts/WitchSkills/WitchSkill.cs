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

    // ���� �����Ҷ� ����
    public void BattleStart()
    {
        nowCoolTime = this.startCoolTime;

        isUsed = nowCoolTime <= 0 ? false : true;
    }
    
    // ���ʸ� ������ �� ����
    public void TurnStart()
    {

    }

    // ���ʸ� ���� �� �� ����
    public void TurnEnd()
    {
        reduceCoolTime(1);
    }

    // ���� ����
    public void Use()
    {
        nowCoolTime = maxCoolTime;
        isUsed = true;
    }

    // ���� ����
    public void Use(GameObject target)
    {
        nowCoolTime = maxCoolTime;
        isUsed = true;

        Debug.Log("WitchSkill Use : " + name + " target > " + target.name);
    }

    // ��Ÿ�� ���� �Լ�
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
