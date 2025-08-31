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

        // ���׹߻�, ������ ��ġ���� �ٲ�鼭 ����� ������ ���̴µ� ������ �� �𸣰���

        AddCard(new HorizonAtk7Card(GetCharacter(), "Ⱦ����"));
        AddCard(new HorizonAtk7Card(GetCharacter(), "Ⱦ����"));
        AddCard(new VerticalAtk7Card(GetCharacter(), "������"));
        AddCard(new VerticalAtk7Card(GetCharacter(), "������"));

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
