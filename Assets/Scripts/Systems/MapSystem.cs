using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GWMonsterVer_0_1;
using GWMapVer_0_1;

public class MapSystem : MonoBehaviour
{
    public static MapSystem Instance;
    Map prevMap;
    public Map nowMap { private set; get; }
    public Map nextMap;
    List<Map> battleMaps;
    List<Map> campMaps;
    List<Map> eventMaps;
    List<Map> shopMaps;

    public int mapProgress;

    public SelectUI SelectUI;
    public EventUI EventUI;
    public ShopUI ShopUI;
    public CampUI CampUI;

    public MapState mapState;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        prevMap = null;
        nowMap = null;
        nextMap = null;

        battleMaps = new List<Map>();
        battleMaps.Add(new BattleMap001());
        battleMaps.Add(new BattleMap002());
        battleMaps.Add(new BattleMap003());
        battleMaps.Add(new BattleMap004());

        campMaps = new List<Map>();
        campMaps.Add(new CampMap());

        eventMaps = new List<Map>();
        eventMaps.Add(new EventMap001());

        shopMaps = new List<Map>();
        shopMaps.Add(new ShopMap());

        mapProgress = 1;

        SetNextMap();

        SelectUI = GameObject.Find("SelectUI").GetComponent<SelectUI>();
        EventUI = GameObject.Find("Event Canvas").GetComponent<EventUI>();
        ShopUI = GameObject.Find("Shop Canvas").GetComponent<ShopUI>();
        CampUI = GameObject.Find("Camp Canvas").GetComponent<CampUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextMap()
    {
        nextMap = Progress();
        //nextMap = RandomEventMap();
        //nextMap = ShopMap();
    }

    public void EnterMap()
    {
        prevMap = nowMap;
        nowMap = nextMap;

        mapProgress++;

        Debug.Log("newmap : " + nowMap.mapType.ToString());

        //카메라 전환 & 배틀필드 로드
        if (nowMap.mapType == MapType.Battle)
        {
            mapState = MapState.Battle;

            CameraControlSystem.Instance.ChangeBattle();
            GameLoopSystem.Instance.LoadBattle();
            //            GameLoopSystem.Instance.BattleStart();
        }
        else if (nowMap.mapType == MapType.Camp)
        {
            mapState = MapState.Camp;

            CampUI.SetMap(nowMap as CampMap);
            CameraControlSystem.Instance.ChangeCamp();
        }
        else if (nowMap.mapType == MapType.Event)
        {
            mapState = MapState.Event;

            EventUI.SetMap(nowMap as EventMap);
            CameraControlSystem.Instance.ChangeEvent();
        }
        else if (nowMap.mapType == MapType.Shop)
        {
            mapState = MapState.Shop;

            ShopUI.SetMap(nowMap as ShopMap);
            CameraControlSystem.Instance.ChangeShop();
        }

        SelectUI.UpdateUI();
    }

    // 미리 만들어진 배치로 자동으로 가져 올 수 있는 개선이 필요
    public Map Progress()
    {
        Map returnMap;

        //if (mapProgress % 3 == 0 && mapProgress != 0)
        //    return CampMap().Deepcopy();

        switch (mapProgress % 3)
        {
            //  캠프
            case (0):
                returnMap = CampMap();
                break;
            //  전투
            case (1):
                returnMap = RandomBattleMap();
                break;
            //  랜덤 사건(전투 : 상점 : 이벤트 = 2 : 1 : 1)
            case (2):
                returnMap = RandomEventMap();
                break;
            //  오류
            default:
                returnMap = null;
                Debug.Log("Error : MapSystem_Progress");
                break;
        }

        return returnMap;
    }

    public Map RandomBattleMap()
    {
        int temp = Random.Range(0, battleMaps.Count);

        return battleMaps[temp].Deepcopy();
    }

    //  ? 노드에 들어갈 맵을 선정한다.
    public Map RandomEventMap()
    {
        Map returnMap;

        switch (Random.Range(0,4))
        {
            case (0):
            case (1):
                returnMap = RandomBattleMap();
                break;
            case (2):
                returnMap = RandomOnlyEventMap();
                break;
            case (3):
                returnMap = ShopMap();
                break;
            default:
                returnMap = null;
                Debug.Log("Error : MapSystem_RandomEventMap");
                break;
        }

        return returnMap;
    }

    //  이벤트 맵 중 랜덤한 맵을 선택한다.
    public Map RandomOnlyEventMap()
    {
        int temp = Random.Range(0, eventMaps.Count);

        return eventMaps[temp].Deepcopy();
    }


    public void EscapeMap()
    {
        mapState = MapState.Map;

        SetNextMap();
        CameraControlSystem.Instance.ChangeMap();
    }

    public Map CampMap()
    {
        return campMaps[campMaps.Count - 1].Deepcopy();
    }

    public Map ShopMap()
    {
        return shopMaps[shopMaps.Count - 1].Deepcopy();
    }
}
