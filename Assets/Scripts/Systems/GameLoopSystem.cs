using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLoopSystem : MonoBehaviour
{
    static public GameLoopSystem Instance;
    public bool IsMyTurn;

    public UnityEvent EndUserTurn;

    DeckSystem DeckSystem;
    PartyUI PartyUI;
    BattleField BattleField;
    CostSystem CostSystem;
    public GameObject GORewardUI;
    RewardUI RewardUI;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        IsMyTurn = true;

        //GameObject.Find("BattleField").GetComponent<BattleField>().EndTurn.AddListener(StartMyTurn);

        DeckSystem = GameObject.Find("MySystem").GetComponent<DeckSystem>();
        PartyUI = GameObject.Find("Party").GetComponent<PartyUI>();
        BattleField = GameObject.Find("BattleField").GetComponent<BattleField>();
        CostSystem = GameObject.Find("MySystem").GetComponent<CostSystem>();
        RewardUI = GORewardUI.GetComponent<RewardUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMyTurn()
    {
        IsMyTurn = true;

        PartySystem.Instance.StartTurn();
        

        CostSystem.ResetCost();

        for (int i = 0; i < 5; i++)
            DeckSystem.Draw();

        BattleField.Instance.FindAttack();

        Debug.Log("StartMyTurn End");
    }

    // 유저의 메인은 스스로 카드를 사용하는 등 유니티에서 지원하는 행동을 할 때를 의미

    // 버튼으로 사용
    public void EndMyTurn()
    {
        IsMyTurn = false;
        DeckSystem.DiscardAll();

        PartySystem.Instance.EndTurn();

        //EndUserTurn.Invoke();

        StartEnemyTurn();
        MainEnemyTurn();
        EndEnemyTurn();

        StartMyTurn();

        Debug.Log("EndMyTurn End");
    }

    public void StartEnemyTurn()
    {
        BattleField.Instance.StartTurn();

        Debug.Log("StartEnemyTurn End");
    }

    public void MainEnemyTurn()
    {
        BattleField.Instance.ActivateMonster();

        BattleEffectSystem.Instance.DealBattleEffect();

        Debug.Log("MainEnemyTurn End");
    }

    public void EndEnemyTurn()
    {
        BattleField.Instance.EndTurn();

        //임시
        BattleEffectSystem.Instance.ResetPlayer();
        PartySystem.Instance.CheckBattleEnd();

        Debug.Log("EndEnemyTurn End");
    }


    public void LoadBattle()
    {
        DeckSystem.SetDeck();
        BattleStart();

    }
    public void BattleStart()
    {
        RewardUI.SetActive(false);

        // 각종 값 세팅
        PartyUI.StartUI();
        BattleField.StartGame();

        StartMyTurn();
    }

    public void BattleEnd()
    {
        //PartySystem.Instance.CheckCondition();
        DeckSystem.DiscardAll();
        
        //임시
        BattleEffectSystem.Instance.ResetPlayer();
        Debug.Log("battleEnd 1");
        PartySystem.Instance.EndBattle();
        Debug.Log("battleEnd 2");
        PartyUI.EndUI();
        Debug.Log("battleEnd 3");
        BattleField.EndGame();
        Debug.Log("battleEnd 4");

        RewardUI.SetActive(true);

        RewardUI.AddReward(new RewardStruct(RewardType.Money, Random.Range(75, 90), "money"));
        // 임시 보상임
        //RewardUI.AddReward(new RewardStruct(RewardType.Item, 0, "T_001"));


        //MapSystem.Instance.EscapeMap();

        //임시 보상 처리


        //PlayerData.Instance.AddMoney(Random.Range(1, 10));
    }
}
