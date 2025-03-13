using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardUI : MonoBehaviour
{
    HandUI handUI;
    DeckSystem deckSystem;
    public Card myCard;
    public Vector3 baseScale;
    public bool active;

    GameLoopSystem GameLoopSystem;

    // Start is called before the first frame update
    void Start()
    {
        handUI = GameObject.Find("HandUI").GetComponent<HandUI>();
        deckSystem = GameObject.Find("MySystem").GetComponent<DeckSystem>();

        baseScale = new Vector3(0.1f, 0.1f, 0.15f);
        //myCard = new Card();
        active = false;

        GameLoopSystem = GameObject.Find("MySystem").GetComponent<GameLoopSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Use(GameObject target)
    {
        if (!GameLoopSystem.IsMyTurn)
        {
            Debug.Log("Can not use this card");
            return;
        }
        Debug.Log("Use Card(" + transform.name + ") ");
        if(!myCard.Use(target))
        {
            Debug.Log("Insufficient Cost");
            return;
        }

        handUI.Use(gameObject);
        Debug.Log("mycard : " + myCard.CardName);
        deckSystem.Use(myCard);
    }

    private void OnMouseEnter()
    {
        transform.localScale = baseScale * 1.2f;
    }

    private void OnMouseExit()
    {
        transform.localScale = baseScale;
    }

    private void OnMouseDown()
    {
        active = true;
    }

    private void OnMouseUp()
    {
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
        active = false;
    }

    public void SetMyCard(Card card)
    {
        myCard = card;
        // 이미지 작동은 정상적으로 하나 가독성을 위해 텍스트로 일시적 변경 나중에 프레임과 함께 표시될 예정
        //gameObject.GetComponent<MeshRenderer>().material = myCard.Material;
        transform.GetChild(0).GetComponent<TextMeshPro>().text = myCard.CardName;
        transform.GetChild(1).GetComponent<TextMeshPro>().text = myCard.Description;
        transform.GetChild(2).GetComponent<TextMeshPro>().text = "" + myCard.cost;
        //Debug.Log("setmycard");
    }
}