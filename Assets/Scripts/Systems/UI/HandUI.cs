using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class HandUI : MonoBehaviour
{
    // Hand UI의 길이
    public float length;
    // 간격
    public float xInterval;
    public float zInterval;

    // 손을 어떻게 보여줄지
    public HandSpread spreadType;
    // 손패, 최대 수
    public List<GameObject> hands, remains;
    public int maxHand = 10;

    // 시작, 끝, 중간지점
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
        //  차이만큼 여분(remains)에서 핸드(hands)로 옮김)
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

    // 손패를 곡선으로 나타낸다.
    public void ShowHandCurve(List<Card> hand)
    {
        //  차이만큼 여분(remains)에서 핸드(hands)로 옮김)
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
         * startP : 시작지점
         * endP : 종료 지점
         * wayP : 경유 지점
         * num : 원하는 점의 개수
    */
    public List<Vector3> bezierCurves(Vector3 startP, Vector3 endP, Vector3 wayP, int num)
    {
        /*
         * 계산에 필요한 점들
         * moveP1, moveP2 : 각각 startP~wayP, wayP~endP를 움직이는 점
         * curveP : moveP1~moveP2를 움직이는 점
         */
        Vector3 moveP1 = startP;
        Vector3 moveP2 = wayP;
        Vector3 curveP = moveP1;

        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < num; i++)
        {
            // 어느 위치에 있는지 알기위한 변수
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