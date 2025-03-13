using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUI : MonoBehaviour
{
    public PartyMember myCharacter;
    public Vector3 baseScale;

    Slider hpSlider;
    TextMeshProUGUI hpTextUGUI;

    Slider shieldSlider;
    TextMeshProUGUI shieldTextUGUI;

    // Start is called before the first frame update
    void Start()
    {
        baseScale = new Vector3(1f, 1f, 1f);
        myCharacter.Die.AddListener(Die);
        myCharacter.Change.AddListener(UpdateUI);

        hpSlider = transform.GetChild(1).GetComponent<Slider>();
        shieldSlider = transform.GetChild(2).GetComponent<Slider>();

        hpTextUGUI = transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>();
        shieldTextUGUI = transform.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hited(float damage)
    {
        myCharacter.Hited(damage);
    }

    public void Die()
    {
        Debug.Log(myCharacter.Name + " is Die");
        gameObject.SetActive(false);
    }

    public void SetCharacter(PartyMember character)
    {
        // 임시방편, 유니티 이벤트의 처리를 공통적으로 조율 할 방법이 필요
        character.Die.RemoveAllListeners();

        myCharacter = character;
        myCharacter.SetImage();
        transform.GetChild(0).GetComponent<Image>().sprite = myCharacter.image;

        //Debug.Log("get scale : " + myCharacter.GetScale());
        transform.GetChild(0).localScale = myCharacter.GetScale();

        myCharacter.Die.AddListener(Die);
        myCharacter.Change.AddListener(UpdateUI);
    }

    public void UpdateUI()
    {
        // 슬라이더 조정
        //slider.value = PartySystem.Instance.characters[myCharacter.Pos].Hp / PartySystem.Instance.characters[myCharacter.Pos].MaxHp;
        hpSlider.value = myCharacter.NowHp / myCharacter.MaxHp;
        shieldSlider.value = myCharacter.Shield / myCharacter.MaxHp;


        // 텍스트 조정
        hpTextUGUI.text = "" + myCharacter.NowHp + " / " + myCharacter.MaxHp;
        shieldTextUGUI.text = "" + myCharacter.Shield;

        transform.localScale = baseScale;
    }
}
