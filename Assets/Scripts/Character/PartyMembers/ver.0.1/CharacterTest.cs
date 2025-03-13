using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

using GWCardVer_0_2;

[Serializable]
public class CharacterTest : PartyMember
{
    public CharacterTest(string name = "default", float maxhp = 100, int pos = 0) : base(name, maxhp, pos)
    {
        id = "T_001";

        ResetCards();

        AddCard(new Atk10Card(GetCharacter(), "Test Card1"));
        AddCard(new Atk10Card(GetCharacter(), "Test Card2"));
        AddCard(new Atk10Card(GetCharacter(), "Test Card3"));
        AddCard(new Atk10Card(GetCharacter(), "Test Card4"));
    }
}
