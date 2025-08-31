using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEffectSystem : MonoBehaviour
{
    public static BattleEffectSystem Instance;

    Queue<BattleEffect> battleEffects;

    public List<Character> ActivePlayers;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        battleEffects = new Queue<BattleEffect>();
        ActivePlayers = new List<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // �ϴ� ��÷� ó���ϰ� ����, ��� ���� ó������ ��� �ʿ�
        DealBattleEffect();
        //Debug.Log(Time.time);
    }

    public void RequestBattleEffect(List<BattleEffect> battleEffects)
    {
        foreach (var battleEffect in battleEffects)
            this.battleEffects.Enqueue(battleEffect.DeepCopy());
    }
    
    public void DealBattleEffect()
    {
        if (battleEffects.Count <= 0)
            return;

        while (battleEffects.Count > 0)
        {
            battleEffects.Peek().Active();

            if(battleEffects.Peek().user != null)
                ActivePlayers.Add(battleEffects.Peek().user.GetCharacter());

            // �۵��ߴ��� Ȯ���ϴ� �ܰ�(�̿�)
            Debug.Log("���� ȿ�� ó�� : " + battleEffects.Peek());
            // ������ ����
            battleEffects.Dequeue();
        }
    }

    public bool CheckPlayer(Character character)
    {
        foreach (var c in ActivePlayers)
            if (c != character)
                return true;

        return false;
    }

    public void ResetPlayer()
    {
        ActivePlayers.Clear();
    }
}
