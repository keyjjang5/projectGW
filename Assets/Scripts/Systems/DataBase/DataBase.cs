using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GWItemVer_0_1;

public class DataBase : MonoBehaviour
{
    /*
     * instance : Singleton 패턴 사용
     */

    public static DataBase Instance;

    List<Dictionary<string, object>> ItemData;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        ItemData = Util.CSVParser.Read("Data/Item_Database");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Num 은 모든 아이템의 수와 같다.
    int itemNum = 2;
    public Item GetRandomItem()
    {
        Item returnItem = new Item();
        int random = Random.Range(0, itemNum);
        switch(random)
        {
            case (0):
                returnItem = new Item();
                break;
            case (1):
                returnItem = new GWItemVer_0_1.DefenseBreakItem();
                break;
            default:
                returnItem = new Item();
                break;
        }


        return returnItem;
    }

    public Item GetRandomItemUsingReflecion()
    {
        int randNum = Random.Range(0, ItemData.Count);
        string spaceName = ItemData[randNum]["Namespace"] as string;
        string className = ItemData[randNum]["Class"] as string;
        var type = System.Type.GetType(spaceName + "." + className);

        if (type != null)
        {
            Debug.Log("클래스가 존재합니다.");
        }
        else
        {
            Debug.Log("클래스를 찾을 수 없습니다.");
        }
        var reflectionTest = System.Activator.CreateInstance(type, "name");

        Item returnItem = reflectionTest as Item;
        Debug.Log("DefnseBreak item 추가 성공");
        return returnItem;
    }
}
