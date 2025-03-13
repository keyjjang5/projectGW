using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GWItemVer_0_1;

public class BackpackUI : MonoBehaviour
{
    //public List<Item> items = new List<Item>();
    public Item[] items;
    public List<ActiveSlotUI> slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<ActiveSlotUI>();

        for (int i = 0; i < transform.childCount; i++)
            slots.Add(transform.GetChild(i).GetComponent<ActiveSlotUI>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void AddItem(Item item)
    //{
    //    if (items.Count < 3)
    //        items.Add(item);

    //    foreach(var slot in slots)
    //    {
    //        if (slot.Item != null)
    //            continue;


    //        slot.Item = item;
    //        slot.SetImage();
    //        break;
    //    }
    //    //slots[items.Count - 1].Item = item;
    //    //slots[items.Count - 1].SetImage();
    //}

    public void AddItem(Item item)
    {
        ItemController.Instance.AddItem(item);

        UpdateUI();
    }

    //public void AddItem()
    //{
    //    Item item = new Item();

    //    if (items.Count < 3)
    //        items.Add(item);


    //    foreach (var slot in slots)
    //    {
    //        if (slot.Item != null)
    //            continue;

    //        slot.Item = item;
    //        slot.SetImage();
    //        break;
    //    }

    //    //slots[items.Count - 1].Item = item;
    //    //slots[items.Count - 1].SetImage();

    //    return;
    //}

    public void AddItem()
    {
        ItemController.Instance.AddItem();

        UpdateUI();
    }

    public void UpdateUI()
    {
        List<Item> tempItems = PlayerData.Instance.items;

        // 슬롯 초기화 함수 필요
        foreach (var slot in slots)
            slot.ResetSlot();

        for(int i =0;i<tempItems.Count;i++)
        {
            slots[i].Item = tempItems[i];
            slots[i].SetImage();
        }
    }

    // 사용 안되고 있는 것 같음
    public void Check()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (slots[i].Item != null)
                continue;

            items[i] = null;
        }
    }
}
