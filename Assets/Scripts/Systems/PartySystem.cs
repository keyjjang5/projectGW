using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

// 전투에 들어가면 활성화
public class PartySystem : MonoBehaviour, ITurn
{
    public static PartySystem Instance;
    // 전투가 끝날 때 playerData와 합친다.
    public List<PartyMember> characters;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        SetCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCharacters()
    {
        characters = new List<PartyMember>();

        //characters = PlayerData.Instance.characters.ToList();
        foreach (var character in PlayerData.Instance.characters)
            characters.Add(character.DeepCopy() as PartyMember);

        foreach (var character in characters)
            character.Die.AddListener(CheckBattleEnd);
    }

    public void EndBattle()
    {
        CheckCondition();
        PlayerData.Instance.ChangeCharacters(characters);
    }

    public void Hited(int pos, float value)
    {
        characters[pos].Hited(value);

        PartyUI.Instance.UpdateUI();
    }

    public void AddShield(int pos, float value)
    {
        characters[pos].AddShield(value);

        PartyUI.Instance.UpdateUI();
    }

    public void AddStatusEffect(int pos, StatusEffect statusEffect)
    {
        characters[pos].AddStatusEffect(statusEffect);

        PartyUI.Instance.UpdateUI();
    }

    public void Heal(int pos, float value)
    {
        characters[pos].Heal(value);
        Debug.Log("힐 됨");
        PartyUI.Instance.UpdateUI();
    }

    public GameObject GetRandomTarget()
    {
        List<GameObject> templist = new List<GameObject>();
        for (int i = 0; i < characters.Count; i++)
        {
            if (!characters[i].IsDead)
                templist.Add(PartyUI.Instance.characterUIs[i].gameObject);
        }

        int temp = Random.Range(0, templist.Count);

        return templist[temp];
    }

    public PartyMember GetCRandomTarget()
    {
        List<PartyMember> templist = new List<PartyMember>();
        for (int i = 0; i < characters.Count; i++)
        {
            if (!characters[i].IsDead)
                templist.Add(characters[i]);
        }

        int temp = Random.Range(0, templist.Count);

        return templist[temp];
    }

    public PartyMember GetWeakestTarget()
    {
        // 안죽은 캐릭터 고르기
        List<PartyMember> templist = new List<PartyMember>();
        for (int i = 0; i < characters.Count; i++)
        {
            if (!characters[i].IsDead)
                templist.Add(characters[i]);
        }

        //해당하는 대상 찾기
        float tempHp = 999;
        int weakestPos = -1;
        foreach (var character in templist)
        {
            if (character.IsDead == true)
                continue;

            if (tempHp >= character.NowHp)
            {
                tempHp = character.NowHp;
                weakestPos = character.Pos;
            }

        }

        return templist[weakestPos];
    }

    public bool IsLowHpCharacter(float value)
    {
        foreach(var character in characters)
            if (character.NowHp / character.MaxHp <= value
                && character.NowHp > 0)
                return true;

        return false;
    }

    public void StartTurn()
    {
        foreach (var member in characters)
            member.StartTurn();
    }

    public void EndTurn()
    {
        foreach (var member in characters)
            member.EndTurn();
    }

    public void CheckBattleEnd()
    {
        foreach (var character in characters)
            if (character.IsDead == false)
                return;

        GameLoopSystem.Instance.BattleEnd();

        SceneController.Instance.GameLose();
        //MapSystem.Instance.EscapeMap();
    }

    public void RemoveMember(List<PartyMember> members)
    {
        foreach (var member in members)
            characters.Remove(member);
    }

    public void CheckCondition()
    {
        List<PartyMember> targets = new List<PartyMember>();
        foreach(var member in characters)
        {
            if (member.IsDead)
                targets.Add(member);
        }

        RemoveMember(targets);
    }

    public void Initialize()
    {
        characters.Clear();
        //characters.RemoveRange(0, characters.Count);
    }
}
