using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PartyUI : MonoBehaviour
{
    public static PartyUI Instance;
    PartySystem partySystem;
    public List<CharacterUI> characterUIs;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        partySystem = GameObject.Find("MySystem").GetComponent<PartySystem>();
        StartSetting();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void LateUpdate()
    {
        if (transform.GetChild(0).childCount > 0
            || transform.GetChild(1).childCount > 0
            || transform.GetChild(2).childCount > 0
            || transform.GetChild(3).childCount > 0)
        {
            UpdateUI();
        }
    }

    public void StartSetting()
    {
        // 최대 파티원수가 4명이므로 4
        for (int i = 0; i < 4; i++)
        {
            GameObject temp = Instantiate(Resources.Load("Prefabs/Character/Character") as GameObject);
            temp.transform.SetParent(transform.GetChild(i));
            temp.transform.localPosition = Vector3.zero;
            characterUIs.Add(temp.GetComponent<CharacterUI>());
            temp.SetActive(false);
        }
    }

    public void StartUI()
    {
        partySystem.SetCharacters();

        for (int i = 0; i < partySystem.characters.Count; i++)
        {
            //GameObject temp = Instantiate(Resources.Load("Prefabs/Character/Character") as GameObject);
            //temp.transform.SetParent(transform.GetChild(i));
            //temp.transform.localPosition = Vector3.zero;

            //characterUIs.Add(temp.GetComponent<CharacterUI>());
            characterUIs[i].gameObject.SetActive(true);
            characterUIs[i].SetCharacter(partySystem.characters[i]);
        }

        //UpdateUI();
    }

    public void EndUI()
    {
        partySystem.Initialize();

        for (int i = 0; i < partySystem.characters.Count; i++)
            characterUIs[i].gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        foreach (var temp in characterUIs)
            if (temp.gameObject.activeSelf)
                temp.UpdateUI();
        //for(int i =0;i<partySystem.characters.Count;i++)
        //{
        //    transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<Slider>().value = partySystem.characters[i].Hp / partySystem.characters[i].MaxHp;
        //}
    }
}
