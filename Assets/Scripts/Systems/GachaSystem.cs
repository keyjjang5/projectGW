using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        gradeWeights.Add(50.0f);
        gradeWeights.Add(35.0f);
        gradeWeights.Add(15.0f);
        gradeWeights.Add(5.0f);

        membersWeight = new Dictionary<string, float>();

        PartyMember temp = new CharacterA("GachaA", 42);
        rare1Pool.Add(temp.id, temp);
        temp = new CharacterB("GachaB", 45);
        rare2Pool.Add(temp.id, temp);
        temp = new CharacterC("GachaC", 37);
        rare3Pool.Add(temp.id, temp);
        temp = new CharacterD("GachaD", 32);
        rare4Pool.Add(temp.id, temp);

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

        CloseSelectUI();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        PlayerData.Instance.RemoveCharacter(i);
        PlayerData.Instance.AddCharacter(tempMember);

        CloseSelectUI();
        MapSystem.Instance.EscapeMap();
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
