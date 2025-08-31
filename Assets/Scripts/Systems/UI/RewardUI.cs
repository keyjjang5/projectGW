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
        Debug.Log("��ư����");
        // ��ư ����
        var temp = Instantiate(Resources.Load("Image/UIs/ItemButton") as GameObject);
        temp.transform.SetParent(transform.GetChild(0).GetChild(0));
        rewards.Add(temp);
        switch(reward.rewardType)
        {
            case (RewardType.Money):
                temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "��ȥ : " + reward.value;
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
        Debug.Log("���� �ȸ���");
        // id�� ���ؼ� ������ ã�ƿ��� ������ �������� �о����
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
