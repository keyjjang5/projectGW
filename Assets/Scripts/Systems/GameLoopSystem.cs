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

    // ������ ������ ������ ī�带 ����ϴ� �� ����Ƽ���� �����ϴ� �ൿ�� �� ���� �ǹ�

    // ��ư���� ���
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

        BattleEffectSystem.Instance.dealBattleEffect();

        Debug.Log("MainEnemyTurn End");
    }

    public void EndEnemyTurn()
    {
        BattleField.Instance.EndTurn();

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

        // ���� �� ����
        PartyUI.StartUI();
        BattleField.StartGame();

        StartMyTurn();
    }

    public void BattleEnd()
    {
        //PartySystem.Instance.CheckCondition();
        DeckSystem.DiscardAll();
        PartySystem.Instance.EndBattle();
        PartyUI.EndUI();
        BattleField.EndGame();

        RewardUI.SetActive(true);

        RewardUI.AddReward(new RewardStruct(RewardType.Money, Random.Range(30, 80), "money"));
        // �ӽ� ������
        RewardUI.AddReward(new RewardStruct(RewardType.Item, 0, "T_001"));


        //MapSystem.Instance.EscapeMap();

        //�ӽ� ���� ó��


        //PlayerData.Instance.AddMoney(Random.Range(1, 10));
    }
}
