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
        // 일단 상시로 처리하게 했음, 어디서 언제 처리할지 고민 필요
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

            // 작동했는지 확인하는 단계(미완)
            Debug.Log("전투 효과 처리 : " + battleEffects.Peek());
            // 실제로 제거
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
