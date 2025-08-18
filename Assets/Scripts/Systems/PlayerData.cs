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

        // �ӽ÷� ĳ���� �߰��κ�
        //AddCharacter(new Character("test1"));
        //AddCharacter(new Character("test2"));
        //AddCharacter(new CharacterA("AttackAndDefense1", 42));
        //AddCharacter(new CharacterB("AttackAndDefense2", 45));
        //AddCharacter(new CharacterC("Healer", 37));
        //AddCharacter(new CharacterD("Mage", 32));
        //AddCharacter(new CharacterTest("atkcardTest", 30));

        //AddCharacter(new CharacterIPC_A("Fire_Exorcist", 30));
        AddCharacter(new CharacterIPC_B("Standard_Warrior", 40));
        //AddCharacter(new CharacterIPC_C("Archer", 37));
        //AddCharacter(new CharacterIPC_D("Wizard", 35));
        //AddCharacter(new CharacterIPC_F("CrossbowMan", 35));
        AddCharacter(new CharacterIPC_G("SpearMan", 40));
        //AddCharacter(new CharacterIPC_H("Healer", 33));

        // �̿�ĳ
        //AddCharacter(new CharacterIPC_E("Paladin", 45));

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
        
        // ��ä����
        // ��ü or ������
        Debug.Log("�� �̻� ���� �� ����");
        return false;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Contains(item) == false)
            return false;

        items.Remove(item);

        Debug.Log("�����");

        return true;
    }

    public void AddCharacter(PartyMember character)
    {
        character.SetPos(characters.Count);
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
