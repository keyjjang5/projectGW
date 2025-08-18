using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEffectSystem : MonoBehaviour
{
    public static BattleEffectSystem Instance;

    Queue<BattleEffect> battleEffects;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        battleEffects = new Queue<BattleEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // �ϴ� ��÷� ó���ϰ� ����, ��� ���� ó������ ��� �ʿ�
        dealBattleEffect();
        //Debug.Log(Time.time);
    }

    public void RequestBattleEffect(List<BattleEffect> battleEffects)
    {
        foreach (var battleEffect in battleEffects)
            this.battleEffects.Enqueue(battleEffect.DeepCopy());
        //Debug.Log(Time.time);
    }
    
    public void dealBattleEffect()
    {
        if (battleEffects.Count <= 0)
            return;

        while (battleEffects.Count > 0)
        {
            battleEffects.Peek().Active();
            // �۵��ߴ��� Ȯ���ϴ� �ܰ�(�̿�)
            Debug.Log("���� ȿ�� ó�� : " + battleEffects.Peek());
            // ������ ����
            battleEffects.Dequeue();
        }
    }
}
