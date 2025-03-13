using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using GWMapVer_0_1;
public class ShopUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMap(ShopMap shopMap)
    {
        //SetItems(transform.GetChild(0), shopMap.shopItems);

        SetItemsNTears(transform.GetChild(0), shopMap.shopItems, shopMap.shopTears);

    }

    public void SetItems(Transform target, List<shopItem> items)
    {
        int i = 0;
        foreach (var item in items)
        {
            SetImage(target.GetChild(i), item.sprite);
            SetText(target.GetChild(i), item.text);
            Debug.Log("num : " + item.button.Count);
            SetButton(target.GetChild(i), item.button);
            i++;
        }
    }

    public void SetItemsNTears(Transform target, List<shopItem> items, List<shopItem> tears)
    {
        int i = 0;
        foreach (var item in items)
        {
            SetImage(target.GetChild(i), item.sprite);
            SetText(target.GetChild(i), item.text);
            Debug.Log("num : " + item.button.Count);
            SetButton(target.GetChild(i), item.button);
            i++;
        }

        foreach(var tear in tears)
        {
            SetImage(target.GetChild(i), tear.sprite);
            SetText(target.GetChild(i), tear.text);
            Debug.Log("num : " + tear.button.Count);
            SetButton(target.GetChild(i), tear.button);
            i++;
        }
    }

    public void SetText(Transform target, string text)
    {
        target.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void SetImage(Transform target, Sprite sprite)
    {
        target.GetComponentInChildren<Image>().sprite = sprite;
    }

    public void SetButton(Transform target, List<m_Delegate> button)
    {
        foreach (var method in button)
        {
            target.GetComponentInChildren<Button>().onClick.AddListener(() => Debug.Log("test"));
            target.GetComponentInChildren<Button>().onClick.AddListener(delegate { method(); });
        }
    }

    public void SetButtons(List<m_Delegate> button1, List<m_Delegate> button2)
    {
        var button = transform.GetChild(0).GetChild(0).GetComponent<Button>();

        button.onClick.RemoveAllListeners();
        foreach (var method in button1)
            button.onClick.AddListener(delegate { method(); });

        button.onClick.AddListener(() => MapSystem.Instance.EscapeMap());

        button = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        foreach (var method in button2)
            button.onClick.AddListener(delegate { method(); });

        button.onClick.AddListener(() => MapSystem.Instance.EscapeMap());
    }
}
