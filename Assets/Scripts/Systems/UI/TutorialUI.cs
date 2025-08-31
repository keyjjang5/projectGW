using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    GameObject campTutorial;
    GameObject battleTutorial;
    int now;

    // Start is called before the first frame update
    void Start()
    {
        campTutorial = GameObject.Find("Camp Canvas").transform.Find("Tutorial").gameObject;
        battleTutorial = GameObject.Find("BattleCanvas").transform.Find("Tutorial").gameObject;
        now = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCampTutorial()
    {
        now = 0;

        campTutorial.SetActive(false);
    }

    public void NextCampTutorial()
    {
        campTutorial.transform.GetChild(now).gameObject.SetActive(false);
        now += 1;
        campTutorial.transform.GetChild(now).gameObject.SetActive(true);
    }

    public void CloseBattleTutorial()
    {
        now = 0;

        battleTutorial.SetActive(false);
    }

    public void NextBattleTutorial()
    {
        battleTutorial.transform.GetChild(now).gameObject.SetActive(false);
        now += 1;
        battleTutorial.transform.GetChild(now).gameObject.SetActive(true);
    }
}
