using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostUI : MonoBehaviour
{
    CostSystem CostSystem;

    // Start is called before the first frame update
    void Start()
    {
        CostSystem = GameObject.Find("MySystem").GetComponent<CostSystem>();

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = CostSystem.nowAp + "/" + CostSystem.maxAp;
    }
}
