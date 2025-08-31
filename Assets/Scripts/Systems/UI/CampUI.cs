using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using GWMapVer_0_1;

public class CampUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMap(CampMap campMap)
    {
        //SetText(eventMap.text);
        //SetMainImage(eventMap.sprite);
        SetButtons(campMap.button1, campMap.button2, campMap.button3);

        var button = transform.GetChild(6).GetChild(4).GetChild(0).GetComponent<Button>();
        foreach (var method in campMap.button2)
            button.onClick.AddListener(delegate { method(); });

        button.onClick.AddListener(() => MapSystem.Instance.EscapeMap());
    }

    public void SetText(string text)
    {
        transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = text;
    }

    public void SetMainImage(Sprite sprite)
    {
        transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = sprite;
    }

    /*
     *  button1 : Gacha
     *  button2 : Rest
     *  button3 : Talk(¹Ì±¸Çö)
     */
    public void SetButtons(List<m_Delegate> button1, List<m_Delegate> button2, List<m_Delegate> button3)
    {
        var button = transform.GetChild(1).GetComponent<Button>();

        button.onClick.RemoveAllListeners();
        foreach (var method in button1)
            button.onClick.AddListener(delegate { method(); });

        //button.onClick.AddListener(() => MapSystem.Instance.EscapeMap());


        button = transform.GetChild(2).GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        foreach (var method in button2)
            button.onClick.AddListener(delegate { method(); });

        button.onClick.AddListener(() => MapSystem.Instance.EscapeMap());

        
        button = transform.GetChild(3).GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        foreach (var method in button3)
            button.onClick.AddListener(delegate { method(); });

        button.onClick.AddListener(() => MapSystem.Instance.EscapeMap());
    }
}
