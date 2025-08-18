using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using GWMonsterVer_0_1;

public class BattleField : MonoBehaviour, ITurn
{
    public static BattleField Instance;

    public List<Transform> vertexs;
    public List<Vector3> spawns;
    public List<bool> isSpawn;
    //public List<GameObject> monsters;
    public List<Monster> monsters;
    List<GameObject> goMonsters;

    public int divisionNum;
    public Vector2 pivot;

    public Camera battleFieldCamera;

    public GameObject RewardUI;

    //public UnityEvent EndTurn;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        vertexs = new List<Transform>();
        spawns = new List<Vector3>();
        divisionNum = 3;

        goMonsters = new List<GameObject>();

        battleFieldCamera = GameObject.Find("Battle Camera").GetComponent<Camera>();

        Transform tempField = transform.GetChild(0);
        for (int i = 0; i < tempField.childCount; i++)
            vertexs.Add(tempField.GetChild(i));

        //SetSpawnPoints();
        ssetSpawnPoints();

        //List<int> sp = new List<int>
        //{
        //    1,
        //    3,
        //    5,
        //    7
        //};
        //SpawnMonsters(sp);

        //GameObject.Find("MySystem").GetComponent<GameLoopSystem>().EndUserTurn.AddListener(ActivateMonster);

        //EndTurn.AddListener(ReduceCooltime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        UpdateUI();
    }

    // 스폰지점을 설정하는 함수
    void SetSpawnPoints()
    {
        List<Vector3> horizontalPoints = new List<Vector3>();
        List<Vector3> verticalPoints = new List<Vector3>();

        for (int i = 0; i < divisionNum; i++)
        {
            float weight = (float)i / divisionNum;
            horizontalPoints.Add(Vector3.Lerp(vertexs[2].position, vertexs[3].position, weight));
            verticalPoints.Add(Vector3.Lerp(vertexs[2].position, vertexs[0].position, weight));
        }

        for (int i = 0; i < divisionNum; i++)
            for (int j = 0; j < divisionNum; j++)
            {
                spawns.Add(new Vector3(horizontalPoints[j].x, verticalPoints[i].y, verticalPoints[i].z));
                isSpawn.Add(false);
            }

        var hInterval = horizontalPoints[1] - horizontalPoints[0];
        var vInterval = verticalPoints[1] - verticalPoints[0];
        for (int i = 0; i < spawns.Count; i++)
        {
            spawns[i] = spawns[i] + pivot.x * hInterval + pivot.y * vInterval;
        }
    }
    // 250730 새로만드는 포인트 생성함수 미완성
    void ssetSpawnPoints()
    {
        List<Vector3> verticalPointsLeft = new List<Vector3>();
        List<Vector3> verticalPointsRight = new List<Vector3>();

        //for (int i = 0; i < divisionNum; i++)
        //{
        //    float weight = (float)i / divisionNum;

        //    verticalPointsLeft.Add(Vector3.Lerp(vertexs[2].position, vertexs[0].position, weight));
        //    verticalPointsRight.Add(Vector3.Lerp(vertexs[3].position, vertexs[1].position, weight));
        //}

        verticalPointsLeft.Add(Vector3.Lerp(vertexs[2].position, vertexs[0].position, 0));
        verticalPointsLeft.Add(Vector3.Lerp(vertexs[2].position, vertexs[0].position, (float)50/100));
        verticalPointsLeft.Add(Vector3.Lerp(vertexs[2].position, vertexs[0].position, (float)75/100));

        verticalPointsRight.Add(Vector3.Lerp(vertexs[3].position, vertexs[1].position, 0));
        verticalPointsRight.Add(Vector3.Lerp(vertexs[3].position, vertexs[1].position, (float)50 / 100));
        verticalPointsRight.Add(Vector3.Lerp(vertexs[3].position, vertexs[1].position, (float)75 / 100));

        List<Vector3> horizonTemp = new List<Vector3>();
        List<Vector3> verticalTemp = new List<Vector3>();
        for (int i = 0; i < divisionNum; i++)
        {
            for (int j = 0; j < divisionNum; j++)
            {
                //float weight = (float)j / divisionNum;
                float weight = (float)1 / (divisionNum * 2) + (float)j / divisionNum;
                verticalTemp.Add(Vector3.Lerp(verticalPointsLeft[i], verticalPointsRight[i], weight));
            }
            
        }

        for (int i = 0; i < verticalTemp.Count; i++)
        {
            spawns.Add(new Vector3(verticalTemp[i].x, verticalTemp[i].y + 1, verticalTemp[i].z));
            isSpawn.Add(false);
        }

        //var hInterval = verticalTemp[1] - verticalTemp[0];
        //var vInterval = verticalTemp[3] - verticalTemp[0];
        //for (int i = 0; i < spawns.Count; i++)
        //{
        //    spawns[i] = spawns[i] + pivot.x * hInterval + pivot.y * vInterval;
        //}
    }

    //몬스터 스폰 함수
    //pos의 위치에만 몬스터를 스폰한다.
    void SpawnMonsters(List<int> pos)
    {
        pos.Sort();

        foreach(var p in pos)
        {
            var temp = Instantiate(Resources.Load("Prefabs/Monsters/BaseMonster") as GameObject);
            temp.transform.Translate(spawns[p]);
            temp.transform.SetParent(transform);
        }
        for (int i = 0; i < spawns.Count; i++)
        {
            if (!pos.Contains(i))
                continue;

            var temp = Instantiate(Resources.Load("Prefabs/Monsters/BaseMonster") as GameObject);
            temp.transform.Translate(spawns[i]);
            temp.transform.SetParent(transform);
        }
        //foreach (var spawn in spawns)
        //{
        //    var temp = Instantiate(Resources.Load("Prefabs/Monsters/BaseMonster") as GameObject);
        //    temp.transform.Translate(spawn);
        //}
    }

    void SpawnMonsters(List<Monster> monsters)
    {
        foreach(var monster in monsters)
        {
            var temp = Instantiate(Resources.Load("Prefabs/Monsters/TestMonster") as GameObject);
            temp.transform.Translate(spawns[monster.Pos]);
            temp.GetComponent<MonsterUI>().SetMonster(monster);
            temp.transform.SetParent(transform);

            goMonsters.Add(temp);

            isSpawn[monster.Pos] = true;

            //this.monsters.Add(temp);
        }
    }

    public void ActivateMonster()
    {
        foreach(var monster in monsters)
        {
            if (monster.IsDead)
                continue;

            monster.Action();
        }

        //EndTurn.Invoke();
    }

    public void SetMonster()
    {
        monsters = MapSystem.Instance.nowMap.monsters;

        foreach (var monster in monsters)
        {
            monster.Die.AddListener(CheckBattleEnd);
            monster.Die.AddListener(CheckMonsters);
        }
    }

    // 원하는 몬스터를 원하는 위치에 스폰함.
    public void SetRandomMonster()
    {
        int temp = Random.Range(0, 3);
        Debug.Log("temp = " + temp);
        switch(temp)
        {
            case (0):
                monsters = new List<Monster>()
                {
                    //new MonsterA("MonsterA", 20, 0)
                    //new MonsterB("MonsterB", 17, 2)
                    new MonsterC("MonsterC", 23, 1),
                    new MonsterD("MonsterD", 15, 5)
                    //new MonsterD("MonsterD", 4)
                };
                break;
            case (1):
                monsters = new List<Monster>()
                {
                    new MonsterA("MonsterA1", 20, 0),
                    new MonsterA("MonsterA1", 20, 3),
                    new MonsterB("MonsterA1", 20, 7)
                };
                break;
            case (2):
                monsters = new List<Monster>()
                {
                    new MonsterC("MonsterA1", 20, 1),
                    new MonsterB("MonsterA1", 20, 4),
                    new MonsterA("MonsterA1", 20, 6)
                };
                break;
            default:
                break;
        }
    }

    public void StartGame()
    {
        //SetRandomMonster();
        SetMonster();

        SpawnMonsters(monsters);
    }

    public void EndGame()
    {
        RemoveMonsters();
    }

    public void RemoveMonsters()
    {
        for (int i = 0; i < isSpawn.Count; i++)
            isSpawn[i] = false;

        foreach (var goMonster in goMonsters)
            Destroy(goMonster);

        goMonsters.Clear();
    }

    public Monster SearchMonster(int pos)
    {
        foreach (var monster in monsters)
            if (monster.Pos == pos)
                return monster;

        return null;
    }

    public void Hited(int pos, float value)
    {
        if (SearchMonster(pos) != null)
            SearchMonster(pos).Hited(value);
        else
            Debug.Log("대상이 없습니다 : " + pos);

        UpdateUI();

        //bool isHit = false;
        //foreach (var monster in monsters)
        //{
        //    if (monster.Pos == pos)
        //    {
        //        monster.Hited(value);
        //        isHit = true;
        //        break;
        //    }
        //}
        //if (!isHit)
        //    Debug.Log("대상이 없습니다");
    }

    public void Heal(int pos, float value)
    {
        if (SearchMonster(pos) != null)
            SearchMonster(pos).Heal(value);
        else
            Debug.Log("대상이 없습니다");

        UpdateUI();
    }

    // 밀치기, length만큼 뒤로 이동된다.
    public void Knockback(int pos, int length)
    {
        
        for (int i = 0; i < length; i++)
        {
            if (SearchMonster(pos + 3 * (i + 1)) != null)
            {
                Debug.Log("Knockback fail");
                break;
            }
            else if (pos + 3 * (i + 1) > 8)
            {
                Debug.Log("Insufficient Space");
                return;
            }
            SearchMonster(pos + 3 * i).Pos = pos + 3 * (i + 1);
        }
        UpdateUI();
    }

    public void MoveForward(int pos, int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (SearchMonster(pos - 3 * (i + 1)) != null)
            {
                Debug.Log("Knockback fail");
                break;
            }
            else if (pos - 3 * (i + 1) < 0)
            {
                Debug.Log("Insufficient Space");
                return;
            }
            SearchMonster(pos - 3 * i).Pos = pos - 3 * (i + 1);
        }
        UpdateUI();
    }

    public void MoveLeft(int pos, int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (SearchMonster((pos - 1 - i)%3 < 2 ? pos - i - 1 : pos - i) != null)
            {
                Debug.Log("MoveLeft fail");
                break;
            }
            SearchMonster(pos - 1 * i).Pos = pos - 1 * (i + 1);
        }
        UpdateUI();
    }

    public void MoveRight(int pos, int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (SearchMonster((pos + 1 + i) % 3 > 0 ? pos + i + 1 : pos + i) != null)
            {
                Debug.Log("MoveRight fail");
                break;
            }
            SearchMonster(pos + 1 * i).Pos = pos + 1 * (i + 1);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach(var monster in goMonsters)
        {
            if (!monster.activeSelf)
                continue;
            if (monster.GetComponent<MonsterUI>() == null)
                continue;
            monster.GetComponent<MonsterUI>().UpdateUI();
        }
    }

    public Vector3 GetPos(int pos)
    {
        return spawns[pos];
    }

    public void AddShield(int pos, float value)
    {
        if (SearchMonster(pos) != null)
            SearchMonster(pos).AddShield(value);
        else
            Debug.Log("대상이 없습니다");

        UpdateUI();
    }

    public void AddStatusEffect(int pos, StatusEffect statusEffect)
    {
        if (SearchMonster(pos) != null)
            SearchMonster(pos).AddStatusEffect(statusEffect);
        else
            Debug.Log("대상이 없습니다");

        UpdateUI();
    }

    public void ReduceCooltime()
    {
        foreach (var monster in monsters)
            foreach (var attack in monster.Attacks)
                attack.ReduceCooltime(1);
            //foreach(var battleEffect in monster.BattleEffects)
            //    battleEffect.ReduceCooltime(1);

        Debug.Log("ReduceCooltime");
    }

    public void StartTurn()
    {
        foreach (var monster in monsters)
            monster.StartTurn();
    }

    public void EndTurn()
    {
        ReduceCooltime();
        foreach (var monster in monsters)
            monster.EndTurn();

        if(IsFirstLineClear())
            AllMoveForward();
    }

    public void FindAttack()
    {
        foreach (var monster in monsters)
            monster.FindAttack();

        //GameObject.Find("BattleCanvas/Attack").GetComponent<AttackUI>().UpdateUI();
        GameObject.Find("BattleCanvas/Attack").GetComponent<AttackUI>().UpdateUI();
    }

    public Attack GetAttack(int pos)
    {
        Attack temp = new Attack(IconType.NormalAttack, 0f);

        foreach (var monster in monsters)
            if (monster.Pos == pos)
                temp = monster.NowAttack;

        return temp;
    }
    
    public Vector3 GetMonsterPos(int pos)
    {
        Vector3 temp;
        int index = 0;
        index = monsters.FindIndex(monster => monster.Pos == pos);
        temp = battleFieldCamera.WorldToScreenPoint(goMonsters[index].transform.position);
        //Camera.main.WorldToScreenPoint(goMonsters[index].transform.position);


        return temp;
    }

    public void AllMoveForward()
    {
        foreach (var monster in monsters)
            MoveForward(monster.Pos, 1);
    }

    public bool IsFirstLineClear()
    {
        foreach (var monster in monsters)
            if (monster.Pos == 0 || monster.Pos == 1 || monster.Pos == 2)
                return false;

        return true;
    }

    public void CheckBattleEnd()
    {
        foreach (var monster in monsters)
            if (monster.IsDead == false)
                return;

        GameLoopSystem.Instance.BattleEnd();
    }

    void CheckMonsters()
    {
        List<GameObject> goRemoveList = new List<GameObject>();
        List<Monster> removeList = new List<Monster>();

        foreach(var mon in goMonsters)
        {
            var temp = mon.GetComponent<MonsterUI>().myMonster;
            if (temp.NowHp <= 0)
            {
                removeList.Add(temp);
                goRemoveList.Add(mon);
            }
        }

        foreach (var mon in removeList)
            monsters.Remove(mon);

        foreach (var mon in goRemoveList)
            goMonsters.Remove(mon);
    }
}
