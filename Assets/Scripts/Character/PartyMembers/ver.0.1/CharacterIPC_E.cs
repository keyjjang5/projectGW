using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

using GWCardVer_0_2;

[Serializable]
public class CharacterIPC_E : PartyMember
{
    public CharacterIPC_E(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        id = "C_009";
        SetImage();
        //image = Resources.Load<Sprite>("Image/Characters/Tears/" + id + ".png");
        ResetCards();

        AddCard(new SingleAtk8MoveRightCard(GetCharacter(), "레프트 훅"));
        AddCard(new SingleAtk6SelfHeal2Card(GetCharacter(), "홀리 어택"));
        AddCard(new SingleAtk6SelfHeal2Card(GetCharacter(), "홀리 어택"));
        AddCard(new MassShield8Card(GetCharacter(), "신성한 보호"));
    }

    public override Character DeepCopy()
    {
        PartyMember copy = new CharacterIPC_E();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "C_009";
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
