using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

using GWCardVer_0_2;

[Serializable]
public class CharacterIPC_G : PartyMember
{
    public CharacterIPC_G(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        id = "C_011";
        SetImage();
        //image = Resources.Load<Sprite>("Image/Characters/Tears/" + id + ".png");
        ResetCards();

        AddCard(new ColB2Atk7Card(GetCharacter(), "찌르기"));
        AddCard(new SingleAtk9MoveRightCard(GetCharacter(), "창대 휘두르기"));
        AddCard(new SingleAtk9MoveLeftCard(GetCharacter(), "제압 타격"));
        AddCard(new SingleAtk9MoveForwardCard(GetCharacter(), "창대 걸기"));
    }

    public override Character DeepCopy()
    {
        PartyMember copy = new CharacterIPC_G();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "C_011";
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
