using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RewardUI : MonoBehaviour
{
    public List<GameObject> rewards;

    BackpackUI BackpackUI;

    // Start is called before the first frame update
    void Start()
    {
        rewards = new List<GameObject>();
        BackpackUI = GameObject.Find("ItemPanel").GetComponent<BackpackUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive(bool tf)
    {
        gameObject.SetActive(tf);
    }

    public void AddReward(RewardStruct reward)
    {
        Debug.Log("버튼생성");
        // 버튼 생성
        var temp = Instantiate(Resources.Load("Image/UIs/ItemButton") as GameObject);
        temp.transform.SetParent(transform.GetChild(0).GetChild(0));
        rewards.Add(temp);
        switch(reward.rewardType)
        {
            case (RewardType.Money):
                temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "영혼 : " + reward.value;
                temp.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + reward.value;

                temp.GetComponent<Button>().onClick.AddListener(() => PlayerData.Instance.AddMoney(reward.value));
                temp.GetComponent<Button>().onClick.AddListener(() => Destroy(temp));

                break;
            case (RewardType.Item):
                temp.GetComponent<Button>().onClick.AddListener(() => AddItem(reward.id));
                temp.GetComponent<Button>().onClick.AddListener(() => Destroy(temp));
                break;
            default:
                Debug.Log("Error_RewardUI_AddReward");
                break;
        }
    }

    public void AddItem(string id)
    {
        Debug.Log("아직 안만듬");
        // id를 통해서 아이템 찾아오기 지금은 귀찮으니 밀어버림
        //PlayerData.Instance.AddItem(new Tear());
        ItemController.Instance.AddItem(DataBase.Instance.GetRandomItemUsingReflecion()/*new Tear()*/);

        BackpackUI.UpdateUI();
    }

    public void ResetReward()
    {
        foreach(var reward in rewards)
            Destroy(reward);

        rewards.Clear();
    }
}
