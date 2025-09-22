using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

using GWCardVer_0_2;

[Serializable]
public class CharacterIPC_K : PartyMember
{
    public CharacterIPC_K(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        id = "C_015";
        SetImage();
        //image = Resources.Load<Sprite>("Image/Characters/Tears/" + id + ".png");
        ResetCards();

        // 버그발생, 몬스터의 위치값이 바뀌면서 생기는 문제로 보이는데 이유는 잘 모르겠음

        AddCard(new SingleShield2Cooperation1Card(GetCharacter(), "방패막기"));
        AddCard(new SingleAtk4MoveBackwardCard(GetCharacter(), "방패밀치기"));
        AddCard(new MassShield18Card(GetCharacter(), "대방패"));
        AddCard(new AtkRow9Isolation6Card(GetCharacter(), "방패 충격파"));

    }

    public override Character DeepCopy()
    {
        PartyMember copy = new CharacterIPC_K();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "C_015";
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
