using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostSystem : MonoBehaviour
{
    public static CostSystem Instance;
    public int maxAp;
    public int nowAp;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        maxAp = PlayerData.Instance.maxAp;
        ResetCost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool UseCost(int value)
    {
        if (nowAp - value >= 0)
        {
            nowAp -= value;
            return true;
        }
        else
            return false;
    }

    public void ResetCost()
    {
        nowAp = maxAp;
    }
}
