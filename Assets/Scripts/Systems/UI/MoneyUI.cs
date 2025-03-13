using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerData.Instance.money.ToString();
    }
}
