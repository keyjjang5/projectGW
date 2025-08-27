using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

using GWCardVer_0_2;

[Serializable]
public class CharacterA : PartyMember
{
    public CharacterA(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        id = "C_001";
        SetImage();
        //image = Resources.Load<Sprite>("Image/Characters/Tears/" + id + ".png");
        ResetCards();

        //AddCard(new Attack8Shield5Card(GetCharacter()));
        //AddCard(new Attack8Shield5Card(GetCharacter()));
        //AddCard(new TargetShield7Card(GetCharacter()));
        //AddCard(new RowR2Atk8Card(GetCharacter()));
    }

    public override Character DeepCopy()
    {
        PartyMember copy = new CharacterA();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "C_001";
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
