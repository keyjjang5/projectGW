using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GWItemVer_0_1;

public class ItemController : MonoBehaviour
{
    public static ItemController Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        if (PlayerData.Instance.AddItem(item))
            Debug.Log("���������� �������� �߰���");
        else
            Debug.Log("Error : AddItem");
    }

    // �ӽ� �뵵, �Է� ���� ������ �������� ȹ�� �Ѵ�.
    public void AddItem()
    {
        Item temp = DataBase.Instance.GetRandomItem();
        if (PlayerData.Instance.AddItem(temp/*new DefenseBreakItem()*/))
            Debug.Log("���������� �������� �߰���");
        else
            Debug.Log("Error : AddItem");
    }

    // �ӽ÷� ���� Additem�� ��ġ�� ǥ�� �ϱ� ���� �Լ�
    public void TempAddItem()
    {

    }

    // ������ �������� ã�� �Լ�
    //public string GetRandomItemID()
    //{

    //}
}
