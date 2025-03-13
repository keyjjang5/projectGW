using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

//  아마 곧 지울거임
using UnityEngine.UI;
using TMPro;


public class DeckSystem : MonoBehaviour
{
    static public DeckSystem Instance;

    //  덱 > 핸드 : draw, search
    //  덱 > 무덤 : mill
    //  핸드 > 덱 : handToDeck
    //  핸드 > 무덤 : use, discard
    //  무덤 > 덱 : graveyardToDeck
    //  무덤 > 핸드 : salvage
    public UnityEvent draw, search, mill, handToDeck, use, discard, graveyardToDeck, salvage, exile;
    public CardListEvent draw_deck;
    public List<Card> deck, hand, graveyard, exilezone;
    public GameObject go_deck, go_hand, go_graveyard, go_exilezone;

    PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        // 각 UnityEvent가 없다면 생성한다.
        if (draw == null)
            draw = new UnityEvent();
        if (draw_deck == null)
            draw_deck = new CardListEvent();
        if (search == null)
            search = new UnityEvent();
        if (mill == null)
            mill = new UnityEvent();
        if (handToDeck == null)
            handToDeck = new UnityEvent();
        if (use == null)
            use = new UnityEvent();
        if (discard == null)
            discard = new UnityEvent();
        if (graveyardToDeck == null)
            graveyardToDeck = new UnityEvent();
        if (salvage == null)
            salvage = new UnityEvent();
        if (exile == null)
            exile = new UnityEvent();

        // 각 List가 없다면 생성한다.
        if (deck == null)
            deck = new List<Card>();
        if (hand == null)
            hand = new List<Card>();
        if (graveyard == null)
            graveyard = new List<Card>();
        if (exilezone == null)
            exilezone = new List<Card>();

        playerData = GameObject.Find("Player").GetComponent<PlayerData>();


        draw.AddListener(() => { Debug.Log("draw event"); });
        draw.AddListener(UIUpdate);

        use.AddListener(() => { Debug.Log("Use event"); });
        use.AddListener(UIUpdate);

        graveyardToDeck.AddListener(() => { Debug.Log("GraveyardToDeck event"); });
        graveyardToDeck.AddListener(UIUpdate);

        discard.AddListener(() => { Debug.Log("Discard event"); });
        discard.AddListener(UIUpdate);

        UIUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Draw()
    {
        //  에러 체크
        if (deck.Count < 1)
        {
            if (graveyard.Count < 1)
            {
                Debug.Log("Error : Draw : empty deck");
                return;
            }
            //Debug.Log("Error : Draw : empty deck");

            Recycle();
        }

        //  드로우 실행
        hand.Add(deck[0]);
        deck.RemoveAt(0);

        //  드로우 시 event 발생
        draw.Invoke();
        draw_deck.Invoke(hand);

        return;
    }

    public void Use(Card usedCard)
    {
        // 카드 사용 : 수정필요
        if (!hand.Remove(usedCard))
        {
            Debug.Log("Remove Error");

            return;
        }

        graveyard.Add(usedCard);

        // 사용시 event 발생
        use.Invoke();
    }

    public void Recycle()
    {
        for (int i = 0; i < graveyard.Count;) 
        {
            deck.Add(graveyard[0]);
            graveyard.Remove(graveyard[0]);
        }

        graveyardToDeck.Invoke();

        Shuffle(deck);
    }

    public void DiscardAll()
    {
        for(int i =0;i<hand.Count;)
        {
            graveyard.Add(hand[0]);
            hand.RemoveAt(0);

            discard.Invoke();
        }
    }

    public void UIUpdate()
    {
        go_deck.GetComponentInChildren<TextMeshProUGUI>().text = deck.Count.ToString();
        go_hand.GetComponentInChildren<TextMeshProUGUI>().text = hand.Count.ToString();
        go_graveyard.GetComponentInChildren<TextMeshProUGUI>().text = graveyard.Count.ToString();
        go_exilezone.GetComponentInChildren<TextMeshProUGUI>().text = exilezone.Count.ToString();
    }

    public void SetDeck()
    {
        if (deck.Count > 0)
            deck.Clear();
        if(graveyard.Count>0)
            graveyard.Clear();

        foreach (var character in playerData.characters)
            foreach (var card in character.cards)
                deck.Add(card);

        Shuffle(deck);
    }

    public void Exile(Card card)
    {
        if (deck.Contains(card))
            deck.Remove(card);
        else if (hand.Contains(card))
            hand.Remove(card);
        else if (graveyard.Contains(card))
            graveyard.Remove(card);
    }

    public void Die(PartyMember character)
    {
        playerData.RemoveCharacter(character);
        foreach (var card in character.cards)
            Exile(card);
    }

    public void Die(int pos)
    {
        playerData.RemoveCharacter(playerData.characters[pos]);
        foreach (var card in playerData.characters[pos].cards)
            Exile(card);
    }

    public void Shuffle(List<Card> list)
    {
        System.Random rng = new System.Random();

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
