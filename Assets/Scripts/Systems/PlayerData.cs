using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GWItemVer_0_1;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public int money;
    public List<PartyMember> characters;
    public int maxAp;
    public List<Item> items;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        money = 0;
        maxAp = 3;
        characters = new List<PartyMember>();
        items = new List<Item>();

        // 임시로 캐릭터 추가부분
        //AddCharacter(new Character("test1"));
        //AddCharacter(new Character("test2"));
        //AddCharacter(new CharacterA("AttackAndDefense1", 42));
        //AddCharacter(new CharacterB("AttackAndDefense2", 45));
        //AddCharacter(new CharacterC("Healer", 37));
        //AddCharacter(new CharacterD("Mage", 32));
        //AddCharacter(new CharacterTest("atkcardTest", 30));


        //AddCharacter(new CharacterIPC_A("하나비", 18));
        AddCharacter(new CharacterIPC_B("모니카", 23));
        //AddCharacter(new CharacterIPC_C("사라", 20));
        //AddCharacter(new CharacterIPC_D("리나", 19));
        //AddCharacter(new CharacterIPC_E("엘리시아", 25));
        //AddCharacter(new CharacterIPC_F("셰이드", 21));
        AddCharacter(new CharacterIPC_G("노아", 22));
        //AddCharacter(new CharacterIPC_H("소피", 21));
        //AddCharacter(new CharacterIPC_I("캐서린", 22));
        //AddCharacter(new CharacterIPC_J("제니", 20));
        //AddCharacter(new CharacterIPC_K("힐다", 23));

        //AddCharacter(new CharacterIPC_ChainTest("테스터", 100));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int num)
    {
        money += num;
    }

    public void RemoveMoney(int num)
    {
        money -= num;
        if(money < 0)
        {
            Debug.Log("Error : PlayerData_RemoveMoney");
            money = 0;
        }
    }

    public bool AddItem(Item item)
    {
        if (items.Count < 3 && item != null)
        {
            items.Add(item);

            return true;
        }
        
        // 다채워짐
        // 교체 or 버려짐
        Debug.Log("더 이상 얻을 수 없음");
        return false;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Contains(item) == false)
            return false;

        items.Remove(item);

        Debug.Log("실행됨");

        return true;
    }

    public void AddCharacter(PartyMember character)
    {
        character.SetPos(characters.Count);
        Debug.Log("caracter.cards pos : " + character.cards[0].CardEffects[0].user.GetCharacter().Pos);
        Debug.Log("charactersCount : " + characters.Count);
        characters.Add(character);
    }

    public void RemoveCharacter(PartyMember character)
    {
        characters.Remove(character);
    }

    public void RemoveCharacter(int pos)
    {
        characters.Remove(characters[pos]);

        for (int i = 0; i < characters.Count; i++)
            characters[i].SetPos(i);
    }

    public void RemoveAllCharacter()
    {
        characters.Clear();
    }

    public bool CheckEmptySpace()
    {
        Debug.Log("characters count == " + characters.Count);
        return characters.Count == 4 ? false : true;
    }

    public void ChangeCharacters(List<PartyMember> copys)
    {
        RemoveAllCharacter();
        foreach (var copy in copys)
            characters.Add(copy.DeepCopy() as PartyMember);
    }
}
