using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

[Serializable]
public class Card
{
    public string CardName;
    public string Description;
    public List<BattleEffect> CardEffects;
    public Sprite Sprite;
    public Material Material;
    string imageRoot = "Image/Cards/";
    string materialRoot = "Image/Cards/Materials/";
    public string fileName;
    public int cost;
    public Character parent;


    public Card()
    {
        CardName = "default";
        CardEffects = new List<BattleEffect>();
    }
    public Card(string name)
    {
        CardName = name;
        CardEffects = new List<BattleEffect>();
    }
    public Card(Character parent, string name ="default")
    {
        CardName = name;
        this.parent = parent;
        CardEffects = new List<BattleEffect>();
    }

    // �ӽ÷� ���� �Լ�, �����ʿ�
    public bool Use(GameObject target)
    {
        if (!CostSystem.Instance.UseCost(cost))
        {
            Debug.Log("ī�� ��� ����");
            return false;
        }

        foreach (var effect in CardEffects)
        {
            effect.SetHitbox(target);
            effect.SetUser(parent);
            Debug.Log("effect.pos : " + effect.user.GetCharacter().Pos);
        }
        //�׽�Ʈ
        

        BattleEffectSystem.Instance.RequestBattleEffect(CardEffects);

        return true;
    }

    public void SetImage()
    {
        Sprite = Resources.Load<Sprite>(imageRoot + fileName);
        Material = Resources.Load(materialRoot + fileName) as Material;
    }

    public void AddEffect(BattleEffect battleEffect)
    {
        CardEffects.Add(battleEffect);
    }

    public void SetEffects(List<BattleEffect> battleEffects)
    {
        CardEffects = battleEffects;
    }
}