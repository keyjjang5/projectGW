using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    GameObject campTutorial;

    // Start is called before the first frame update
    void Start()
    {
        campTutorial = GameObject.Find("Camp Canvas").transform.Find("Tutorial").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCampTutorial()
    {
        campTutorial.SetActive(false);
    }
}
