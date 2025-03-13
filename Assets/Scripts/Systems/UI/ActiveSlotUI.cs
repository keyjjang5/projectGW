using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine.Events;
using GWItemVer_0_1;

public class ActiveSlotUI : MonoBehaviour
    , IPointerClickHandler
    , IDragHandler
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerDownHandler
    , IPointerUpHandler
{
    public ActiveSlotType ActiveSlotType;
    public WitchSkill Skill { get; set; }
    public Item Item { get; set; }
    bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        if (transform.parent.GetComponent<WitchSkillUI>() != null)
            ActiveSlotType = ActiveSlotType.WitchSkill;
        else
            ActiveSlotType = ActiveSlotType.Item;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Debug.Log(name + "Game Object Click in Progress");
        switch(ActiveSlotType)
        {
            case (ActiveSlotType.WitchSkill):
                if (Skill == null)
                    return;

                if (Skill.IsUsed)
                {
                    Debug.Log("��ų�� ��� �� �� �����ϴ�.");
                    return;
                }
                break;
            case (ActiveSlotType.Item):
                if (Item == null)
                {
                    Debug.Log("�������� ����ֽ��ϴ�.");
                    return;
                }
                else
                    Debug.Log("mousedown");
                break;
            default:
                break;
        }
        isActive = true;
        Debug.Log("isactive is " + isActive);

        // ���࿡ ���� UIǥ�� ȭ��ǥ�����
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log("isactive is " + isActive);
        //Debug.Log(name + "No longer being clicked");
        if(!isActive)
        {
            Debug.Log("��� �� �� �����ϴ�.");
            return;
        }

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        Input.mousePosition.y, -Camera.main.transform.position.z));

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5000))
        {
            Debug.Log("name : " + hit.collider.name);

            if (hit.collider.tag == "HitBox")
                Use(hit.transform.parent.gameObject);
        }
    }

    void Use(GameObject target)
    {
        switch(ActiveSlotType)
        {
            case (ActiveSlotType.WitchSkill):
                Skill.Use(target);
                break;
            case (ActiveSlotType.Item):
                if (!Item.Use(target))
                {
                    Debug.Log("����� �� ���� �������Դϴ�");
                    return; 
                }
                PlayerData.Instance.RemoveItem(Item);
                ResetSlot();
                break;
            default:
                break;
        }

        isActive = false;
    }

    public void SetImage()
    {
        switch (ActiveSlotType)
        {
            case (ActiveSlotType.WitchSkill):
                gameObject.GetComponent<Image>().sprite = Skill.sprite;
                break;
            case (ActiveSlotType.Item):
                gameObject.GetComponent<Image>().sprite = Item.sprite;

                break;
            default:
                break;
        }

        //gameObject.GetComponent<Image>().sprite = ActiveSlotType == ActiveSlotType.WitchSkill ? Skill.sprite : Item.sprite;
    }

    public void ResetSlot()
    {
        gameObject.GetComponent<Image>().sprite = default;

        Skill = null;
        Item = null;

        isActive = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(name + "Click");
        if(!(Item is Tear))
        {
            Debug.Log("������ �ƴմϴ�!");
            return;
        }
        else if(MapSystem.Instance.mapState != MapState.Camp)
        {
            Debug.Log("ķ���� �ƴմϴ�!");
            return;
        }

        GachaSystem.Instance.SelectGacha((Item as Tear).id);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log(name + "Drag");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log(name + "Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log(name + "Exit");
    }
}
