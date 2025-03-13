using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;


public class AttackUI : MonoBehaviour
{
    public List<GameObject> Attacks;
    public List<Sprite> Sprites;

    public Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        InitializeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeUI()
    {
        scale = new Vector3(1, 1, 1);

        for (int i = 0; i < BattleField.Instance.divisionNum * BattleField.Instance.divisionNum; i++)
        {
            var icon = Instantiate(Resources.Load("Prefabs/Icons/AttackIcon") as GameObject);
            icon.name = "Icon" + i;
            icon.transform.SetParent(transform);
            Attacks.Add(icon);

            icon.transform.localScale = scale;

            icon.SetActive(false);
        }


        Sprites.Add(Resources.Load<Sprite>("Image/TempIcons/level-up"));
        Sprites.Add(Resources.Load<Sprite>("Image/TempIcons/sword"));
    }

    public void ShowUI()
    {
        
    }

    public void UpdateUI()
    {
        // 기존꺼를 안보이게 하기 위함
        foreach (var atk in Attacks)
            atk.SetActive(false);

        //  배틀필드야 몬스터의 정보를 줘
        //  무슨 정보?
        //  어디에 있는 몬스터가 누구를 어떤종류이며 파워 몇으로 대상으로 삼는지
        for (int i = 0; i < BattleField.Instance.divisionNum * BattleField.Instance.divisionNum; i++)
        {
            var tempAttack = BattleField.Instance.GetAttack(i);
            if (tempAttack.BattleEffects.Count <= 0)
                continue;

            //  위치를 업데이트 한다.
            //  배틀필드에게 얻어올 수 있나? 자체 판단 에반데
            Vector3 monsterPos = BattleField.Instance.GetMonsterPos(i);
            //Debug.Log("monsterpos : " + monsterPos);
            var rect = Attacks[i].GetComponent<RectTransform>();
            rect.position = monsterPos;
            //rect.anchoredPosition = monsterPos;

            //UpdateUI(BattleField.Instance.SearchMonster(i));

            //  표시한다.
            Attacks[i].SetActive(true);
        }
    }

    public void improvedUpdateUI()
    {
        foreach (var atk in Attacks)
            atk.SetActive(false);

        foreach(var mon in BattleField.Instance.monsters)
        {
            var rect = Attacks[mon.Pos].GetComponent<RectTransform>();
            rect.position = BattleField.Instance.GetMonsterPos(mon.Pos);

            UpdateUI(mon);

            Attacks[mon.Pos].SetActive(true);
        }
    }

    //  몬스터야 니 정보를 줘
    public void UpdateUI(Monster monster)
    {
        //foreach (var atk in Attacks)
        //    atk.SetActive(false);

        //  아이콘 이미지를 업데이트한다.
        switch (monster.NowAttack.Type)
        {
            case (IconType.Buff):
                Attacks[monster.Pos].GetComponent<Image>().sprite = Sprites[0];
                break;

            case (IconType.NormalAttack):
                Debug.Log("monster.pos : " + Attacks[monster.Pos]);
                Debug.Log("sprites error? : " + Sprites[1]);
                Attacks[monster.Pos].GetComponent<Image>().sprite = Sprites[1];
                break;
        }
        //  nowpower 업데이트
        Attacks[monster.Pos].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = monster.NowAttack.NowPower.ToString();
        //  대상을 업데이트 한다.
        Attacks[monster.Pos].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ">" + monster.target.Pos;
        
    }
}
