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
            Debug.Log("정상적으로 아이템이 추가됨");
        else
            Debug.Log("Error : AddItem");
    }

    // 임시 용도, 입력 없이 정해진 아이템을 획득 한다.
    public void AddItem()
    {
        Item temp = DataBase.Instance.GetRandomItem();
        if (PlayerData.Instance.AddItem(temp/*new DefenseBreakItem()*/))
            Debug.Log("정상적으로 아이템이 추가됨");
        else
            Debug.Log("Error : AddItem");
    }

    // 임시로 만든 Additem의 위치를 표시 하기 위한 함수
    public void TempAddItem()
    {

    }

    // 랜덤한 아이템을 찾는 함수
    //public string GetRandomItemID()
    //{

    //}
}
