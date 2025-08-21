using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ӽ÷� ���� ���� ���콺 ��ġ�� ���� ��Ʈ�ڽ��� ����ǥ�ø� ���ִ� ������Ʈ
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
