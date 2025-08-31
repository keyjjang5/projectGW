using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 나중에 구조 개선하면서 뺄거임
using UnityEngine.UI;
using TMPro;

public class GachaSystem : MonoBehaviour
{
    static public GachaSystem Instance;

    Dictionary<string, PartyMember> rare1Pool;
    Dictionary<string, PartyMember> rare2Pool;
    Dictionary<string, PartyMember> rare3Pool;
    Dictionary<string, PartyMember> rare4Pool;
    List<float> gradeWeights;
    Dictionary<string, float> membersWeight;

    public PartyMember tempMember;

    public GameObject ui;

    public SelectUI SelectUI;

    // 인프챌 추가
    public GameObject gachaUi;
    int nowGachaIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;


        SelectUI = GameObject.Find("SelectUI").GetComponent<SelectUI>();


        // 임의로 50
        rare1Pool = new Dictionary<string, PartyMember>();
        // 임의로 30
        rare2Pool = new Dictionary<string, PartyMember>();
        // 임의로 15
        rare3Pool = new Dictionary<string, PartyMember>();
        // 임의로 5
        rare4Pool = new Dictionary<string, PartyMember>();

        gradeWeights = new List<float>();
        gradeWeights.Add(100.0f);
        // 가중치를 넣는 곳이지만 IPC로 인해서 레어도 1에 몰빵 해놨음
        gradeWeights.Add(0.0f);
        gradeWeights.Add(0.0f);
        gradeWeights.Add(0.0f);

        membersWeight = new Dictionary<string, float>();

        //PartyMember temp = new CharacterA("GachaA", 42);
        //rare1Pool.Add(temp.id, temp);
        //temp = new CharacterB("GachaB", 45);
        //rare2Pool.Add(temp.id, temp);
        //temp = new CharacterC("GachaC", 37);
        //rare3Pool.Add(temp.id, temp);
        //temp = new CharacterD("GachaD", 32);
        //rare4Pool.Add(temp.id, temp);

        PartyMember temp = new CharacterIPC_A("하나비", 18);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_B("모니카", 23);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_C("사라", 20);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_D("리나", 19);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_E("엘리시아", 25);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_F("셰이드", 21);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_G("노아", 22);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_H("소피", 21);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_I("캐서린", 22);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_J("제니", 20);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterIPC_K("힐다", 23);
        rare1Pool.Add(temp.id, temp);




        // 이전에 캐릭터 풀 생성 필요
        foreach (var member in rare1Pool)
        {
            membersWeight.Add(member.Value.id, gradeWeights[0] / rare1Pool.Count);
        }
        foreach (var member in rare2Pool)
        {
            membersWeight.Add(member.Value.id, gradeWeights[1] / rare2Pool.Count);
        }
        foreach (var member in rare3Pool)
        {
            membersWeight.Add(member.Value.id, gradeWeights[2] / rare3Pool.Count);
        }
        foreach (var member in rare4Pool)
        {
            membersWeight.Add(member.Value.id, gradeWeights[3] / rare4Pool.Count);
        }

        for (int i = 3; i < 7; i++)
        {
            var tempCardGo = Instantiate(Resources.Load("Prefabs/Cards/BaseCardUI") as GameObject);

            tempCardGo.transform.SetParent(gachaUi.transform.GetChild(1).GetChild(i));
            tempCardGo.transform.localPosition = Vector3.zero;
        }

        CloseSelectUI();
        CloseGachaUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OpenGachaUI()
    {
        nowGachaIndex = 0;

        gachaUi.SetActive(true);
        gachaUi.transform.GetChild(0).gameObject.SetActive(true);

        for (int i = 1; i < gachaUi.transform.childCount; i++)
            gachaUi.transform.GetChild(i).gameObject.SetActive(false);

    }

    public void CloseGachaUI()
    {
        gachaUi.SetActive(false);
    }

    public void NextGachaUi()
    {
        if (nowGachaIndex < gachaUi.transform.childCount)
        {
            gachaUi.transform.GetChild(nowGachaIndex).gameObject.SetActive(false);
            nowGachaIndex++;
            gachaUi.transform.GetChild(nowGachaIndex).gameObject.SetActive(true);
        }
        else
        {
            gachaUi.transform.GetChild(nowGachaIndex).gameObject.SetActive(false);
            nowGachaIndex = 0;
            gachaUi.transform.GetChild(nowGachaIndex).gameObject.SetActive(true);
        }
    }

    public void GachaIPC()
    {
        if (PlayerData.Instance.money < 100)
        {
            Debug.Log("돈이 부족 합니다");
            return;
        }

        NextGachaUi();
        PlayerData.Instance.RemoveMoney(100);

        var tempId = CharacterIdRandomSelect();
        tempMember = GetPartyMember(tempId);
        SelectUI.UpdateUI();
        // 여기에 캐릭터 결과 나오게 해야함
        gachaUi.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = tempMember.ldImage;
        gachaUi.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = tempMember.Name.Replace("_copy", "");
        string tempInfo;
        switch(tempId)
        {
            case ("C_005"):
                tempInfo = "폭발적인 광역 데미지, 코스트 회복.";
                break;
            case ("C_006"):
                tempInfo = "단일 데미지. 강제 이동.";
                break;
            case ("C_007"):
                tempInfo = "단일 데미지, 드로우.";
                break;
            case ("C_008"):
                tempInfo = "범위 데미지, 드로우.";
                break;
            case ("C_009"):
                tempInfo = "단일 타겟, 자기 회복.";
                break;
            case ("C_010"):
                tempInfo = "강력한 단일딜.";
                break;
            case ("C_011"):
                tempInfo = "직선 데미지 + 이동기믹.";
                break;
            case ("C_012"):
                tempInfo = "힐과 드로우.";
                break;
            case ("C_013"):
                tempInfo = "유틸 및 보조딜.";
                break;
            case ("C_014"):
                tempInfo = "범위 딜 누적.";
                break;
            case ("C_015"):
                tempInfo = "보호막 제공 및 유틸.";
                break;
            default:
                tempInfo = "오류입니다.";
                break;
        }
        gachaUi.transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = tempInfo;
        for(int i = 3; i < tempMember.cards.Count + 3; i++)
        {
            var tempCard = tempMember.cards[i - 3];

            gachaUi.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);

            // 하드코딩으로 이미지 박음
            gachaUi.transform.GetChild(1).GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().sprite = tempCard.Sprite;

            gachaUi.transform.GetChild(1).GetChild(i).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = tempCard.CardName;
            gachaUi.transform.GetChild(1).GetChild(i).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = tempCard.Description;
            gachaUi.transform.GetChild(1).GetChild(i).GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = "" + tempCard.cost;
            gachaUi.transform.GetChild(1).GetChild(i).GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>().text = tempCard.parent.Name;
        }
        for (int i = 3 + tempMember.cards.Count; i < 7; i++)
        {
            gachaUi.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        }
    }

    public void RecruitIPC()
    {
        CloseGachaUI();
        OpenSelectUI();
    }

    public void Gacha()
    {
        if(PlayerData.Instance.money<100)
        {
            Debug.Log("돈이 부족 합니다");
            return;
        }

        PlayerData.Instance.RemoveMoney(100);
        
        var tempId = CharacterIdRandomSelect();
        tempMember = GetPartyMember(tempId);

        Debug.Log("tempid : " + tempId + " / tempMember : " + tempMember.Name);
        SelectUI.UpdateUI();

        // 파티에 공간이 있는지 확인
        // 있다면 자동으로 획득 없다면 선택으로
        if (PlayerData.Instance.CheckEmptySpace())
        {
            PlayerData.Instance.AddCharacter(tempMember);
            //MapSystem.Instance.EscapeMap();
        }
        else
            OpenSelectUI();
            // 추가 UI를 띄움
            // 어느 캐릭터와 바꿀지 or 보석으로 만들지 or 버릴지
        

    }

    // 확정 가챠
    public void SelectGacha(string id)
    {
        tempMember = GetPartyMember(id);

        if (PlayerData.Instance.CheckEmptySpace())
        {
            PlayerData.Instance.AddCharacter(tempMember);
            //MapSystem.Instance.EscapeMap();
        }
        else
            OpenSelectUI();
    }

    public PartyMember GetPartyMember(string id)
    {
        if (rare1Pool.ContainsKey(id))
            return rare1Pool[id].DeepCopy() as PartyMember;
        else if (rare2Pool.ContainsKey(id))
            return rare2Pool[id].DeepCopy() as PartyMember;
        else if (rare3Pool.ContainsKey(id))
            return rare3Pool[id].DeepCopy() as PartyMember;
        else
            return rare4Pool[id].DeepCopy() as PartyMember;
    }

    public string CharacterIdRandomSelect()
    {
        // 총 weight합
        float sum = 0;
        foreach (var weight in membersWeight)
            sum += weight.Value;

        var randomValue = Random.Range(0, sum);

        // 그 중 맞는 값 반환
        float current = 0.0f;
        foreach (var pair in membersWeight)
        {
            current += pair.Value;

            if (randomValue < current)
            {
                return pair.Key;
            }
        }

        return "err_000";
    }

    public void GetNum(int i)
    {
        if(PlayerData.Instance.characters.Count > i)
            PlayerData.Instance.RemoveCharacter(i);
        PlayerData.Instance.AddCharacter(tempMember);

        CloseSelectUI();
        //MapSystem.Instance.EscapeMap();
    }

    public void OpenSelectUI()
    {
        ui.SetActive(true);
    }

    public void CloseSelectUI()
    {
        ui.SetActive(false);
    }
}
