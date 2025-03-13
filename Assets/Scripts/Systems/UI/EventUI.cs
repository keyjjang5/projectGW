using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using GWMapVer_0_1;

public class EventUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMap(EventMap eventMap)
    {
        SetText(eventMap.text);
        SetMainImage(eventMap.sprite);
        SetButtons(eventMap.button1, eventMap.button2);
    }

    public void SetText(string text)
    {
        transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = text;
    }

    public void SetMainImage(Sprite sprite)
    {
        transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = sprite;
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
