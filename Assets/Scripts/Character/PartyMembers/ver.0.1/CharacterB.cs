using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

using GWCardVer_0_2;

[Serializable]
public class CharacterB : PartyMember
{
    public CharacterB(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        id = "C_002";
        SetImage();
        //image = Resources.Load<Sprite>("Image/Characters/Tears/" + id + ".png");
        ResetCards();

        AddCard(new Atk7KBCard(GetCharacter()));
        AddCard(new Atk7KBCard(GetCharacter()));
        AddCard(new TargetShield10Card(GetCharacter()));
        AddCard(new ColB2Atk15Card(GetCharacter()));
    }

    public override Character DeepCopy()
    {
        PartyMember copy = new CharacterB();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "C_002";
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
