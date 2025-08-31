using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

using GWCardVer_0_2;

[Serializable]
public class CharacterIPC_I : PartyMember
{
    public CharacterIPC_I(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        id = "C_013";
        SetImage();
        //image = Resources.Load<Sprite>("Image/Characters/Tears/" + id + ".png");
        ResetCards();

        // 버그발생, 몬스터의 위치값이 바뀌면서 생기는 문제로 보이는데 이유는 잘 모르겠음
        AddCard(new SingleMoveLeftIsolationCard(GetCharacter(), "몰이사냥"));
        AddCard(new SingleMoveRightChainCard(GetCharacter(), "몰이사냥"));
        AddCard(new TargetShield6Card(GetCharacter(), "부상방지"));
        AddCard(new Draw1Card(GetCharacter(), "사냥준비"));
    }

    public override Character DeepCopy()
    {
        PartyMember copy = new CharacterIPC_I();

        copy.NowHp = this.NowHp;
        copy.Name = Name + "_copy";
        copy.id = "C_013";
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
