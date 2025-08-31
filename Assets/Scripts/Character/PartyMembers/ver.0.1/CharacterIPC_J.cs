using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

using GWCardVer_0_2;

[Serializable]
public class CharacterIPC_J : PartyMember
{
    public CharacterIPC_J(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        id = "C_014";
        SetImage();
        //image = Resources.Load<Sprite>("Image/Characters/Tears/" + id + ".png");
        ResetCards();

        // 버그발생, 몬스터의 위치값이 바뀌면서 생기는 문제로 보이는데 이유는 잘 모르겠음

        AddCard(new HorizonAtk7Card(GetCharacter(), "횡베기"));
        AddCard(new HorizonAtk7Card(GetCharacter(), "횡베기"));
        AddCard(new VerticalAtk7Card(GetCharacter(), "종베기"));
        AddCard(new VerticalAtk7Card(GetCharacter(), "종베기"));

    }

    public override Character DeepCopy()
    {
        PartyMember copy = new CharacterIPC_J();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "C_014";
        copy.Pos = Pos;
        copy.time = time;
        copy.MaxHp = MaxHp;
        copy.NowHp = NowHp;
        copy.IsDead = IsDead;

        copy.Die = Die;
        copy.StatusEffects = StatusEffects;
        copy.DamageCalculator = DamageCalculator;
        copy.attackValue = attackValue;
        copy.defenseValue = defenseValue;

        copy.scale = scale;


        copy.draw = draw;
        copy.mana = mana;
        copy.image = image;

        copy.Change = Change;
        copy.cards = cards;

        return copy;
    }
}
