using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 임시로 만든 현재 마우스 위치를 따라서 히트박스의 강조표시를 해주는 컴포넌트
public class TrackingMouseUI : MonoBehaviour
{
    HitBox parent;
    List<GameObject> fields = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.GetComponent<HitBox>();
        for(int i = 0; i < transform.parent.GetChild(1).childCount; i++)
            fields.Add(transform.parent.GetChild(1).GetChild(i).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        int nowPos = parent.SearchPos();

        for(int i = 0; i < fields.Count; i++)
        {
            if (i == nowPos)
                fields[i].SetActive(true);
            else
                fields[i].SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < fields.Count; i++)
                fields[i].SetActive(false);
    }
}
