using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterUI : MonoBehaviour
{
    public Monster myMonster;
    public Vector3 baseScale;

    public float height;
    Slider slider;
    TextMeshProUGUI textUGUI;

    // Start is called before the first frame update
    void Start()
    {
        baseScale = new Vector3(1f, 1f, 1f);
        myMonster.Die.AddListener(Die);

        slider = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        textUGUI = transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        HpbarMove();
    }

    public void Hited(float damage)
    {
        myMonster.Hited(damage);
    }

    public void Die()
    {
        Debug.Log(myMonster.Name + " is Die");
        gameObject.SetActive(false);
    }

    public void SetMonster(Monster monster)
    {
        myMonster = monster;
        myMonster.SetImage();
        transform.GetChild(0).GetComponent<MeshRenderer>().material = myMonster.image;

        //Debug.Log("get scale : " + myMonster.GetScale());
        transform.GetChild(0).localScale = myMonster.GetScale();
    }

    public void UpdateUI()
    {
        transform.position = BattleField.Instance.GetPos(myMonster.Pos);
        slider.value = myMonster.NowHp / myMonster.MaxHp;
        textUGUI.text = "" + myMonster.NowHp + " / " + myMonster.MaxHp;
    }

    // 나중에 수정
    public void HpbarMove()
    {
        Vector3 hpbarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        transform.GetChild(1).GetChild(0).position = hpbarPos;
    }
}
