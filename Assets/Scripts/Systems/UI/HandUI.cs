using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class HandUI : MonoBehaviour
{
    // Hand UI�� ����
    public float length;
    // ����
    public float xInterval;
    public float zInterval;

    // ���� ��� ��������
    public HandSpread spreadType;
    // ����, �ִ� ��
    public List<GameObject> hands, remains;
    public int maxHand = 10;

    // ����, ��, �߰�����
    public Vector3 startP;
    public Vector3 endP;
    public Vector3 wayP;


    // Start is called before the first frame update
    void Start()
    {
        length = 500;
        xInterval = 0.1f;
        zInterval = 0.1f;
        spreadType = HandSpread.Straight;
        hands = new List<GameObject>();
        remains = new List<GameObject>();
        for (int i = 0; i < maxHand; i++)
            remains.Add(Instantiate(Resources.Load("Prefabs/Cards/BaseCard") as GameObject));
        foreach (var go in remains)
            go.transform.SetParent(this.transform);

        DeckSystem deckSys = GameObject.Find("MySystem").GetComponent<DeckSystem>();
        deckSys.draw_deck.AddListener(ShowHandCurve);
        deckSys.draw_deck.AddListener(GetCard);

        deckSys.discard.AddListener(Discard);

        ShowMyHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHandStraight(List<Card> hand)
    {
        //  ���̸�ŭ ����(remains)���� �ڵ�(hands)�� �ű�)
        if (hands.Count != hand.Count)
            for (int i = 0; i < Mathf.Abs(hands.Count - hand.Count); i++)
            {
                hands.Add(remains[0]);
                remains.RemoveAt(0);
            }

        float xStart = -hands.Count / 2 * xInterval;
        float zStart = -hands.Count / 2 * zInterval;

        for (int i = 0; i < hands.Count; i++)
        {
            hands[i].transform.localPosition = Vector3.zero;
            hands[i].transform.Translate(new Vector3(xStart + xInterval * i, zStart + zInterval * i, 0));
        }
    }

    // ���и� ����� ��Ÿ����.
    public void ShowHandCurve(List<Card> hand)
    {
        //  ���̸�ŭ ����(remains)���� �ڵ�(hands)�� �ű�)
        if (hands.Count != hand.Count)
            for (int i = 0; i < Mathf.Abs(hands.Count - hand.Count); i++)
            {
                hands.Add(remains[0]);
                remains.RemoveAt(0);
            }

        ShowMyHand();
        //List<Vector3> points = bezierCurves(startP, endP, wayP, hands.Count);
        //for (int i = 0; i < hands.Count; i++)
        //{
        //    hands[i].transform.localPosition = Vector3.zero;
        //    hands[i].transform.Translate(points[i]);
        //}
    }

    public void ShowMyHand()
    {
        List<Vector3> points = bezierCurves(startP, endP, wayP, hands.Count);

        foreach (var hand in hands)
            hand.SetActive(true);

        for (int i = 0; i < hands.Count; i++)
        {
            hands[i].transform.localPosition = Vector3.zero;
            hands[i].transform.Translate(points[i]);
        }

        foreach (var remain in remains)
            remain.SetActive(false);
    }

    /*
         * startP : ��������
         * endP : ���� ����
         * wayP : ���� ����
         * num : ���ϴ� ���� ����
    */
    public List<Vector3> bezierCurves(Vector3 startP, Vector3 endP, Vector3 wayP, int num)
    {
        /*
         * ��꿡 �ʿ��� ����
         * moveP1, moveP2 : ���� startP~wayP, wayP~endP�� �����̴� ��
         * curveP : moveP1~moveP2�� �����̴� ��
         */
        Vector3 moveP1 = startP;
        Vector3 moveP2 = wayP;
        Vector3 curveP = moveP1;

        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < num; i++)
        {
            // ��� ��ġ�� �ִ��� �˱����� ����
            float weight = (float)(i + 1) / (num + 1);

            moveP1 = Vector3.Lerp(startP, wayP, weight);
            moveP2 = Vector3.Lerp(wayP, endP, weight);
            curveP = Vector3.Lerp(moveP1, moveP2, weight);

            points.Add(curveP);
        }

        return points;
    }


    public void Use(GameObject usedCard)
    {
        remains.Add(usedCard);
        hands.Remove(usedCard);

        ShowMyHand();
    }

    public void Discard()
    {
        int random = Random.Range(0, hands.Count);
        remains.Add(hands[random]);
        hands.RemoveAt(random);

        ShowMyHand();
    }

    public void GetCard(List<Card> hand)
    {
        // Debug.Log("hand[-1] : " + hand[hand.Count-1].CardName);
        hands[hands.Count - 1].GetComponent<CardUI>().SetMyCard(hand[hand.Count - 1]);
    }
}