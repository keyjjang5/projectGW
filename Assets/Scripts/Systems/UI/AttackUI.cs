using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;


public class AttackUI : MonoBehaviour
{
    public List<GameObject> Attacks;
    public List<Sprite> Sprites;

    public Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        InitializeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeUI()
    {
        scale = new Vector3(1, 1, 1);

        for (int i = 0; i < BattleField.Instance.divisionNum * BattleField.Instance.divisionNum; i++)
        {
            var icon = Instantiate(Resources.Load("Prefabs/Icons/AttackLineIcon") as GameObject);
            icon.name = "Icon" + i;
            icon.transform.SetParent(transform);
            Attacks.Add(icon);

            icon.transform.localScale = scale;

            icon.SetActive(false);
        }


        Sprites.Add(Resources.Load<Sprite>("Image/TempIcons/etc"));
        Sprites.Add(Resources.Load<Sprite>("Image/TempIcons/Attack"));
        Sprites.Add(Resources.Load<Sprite>("Image/TempIcons/Defense"));
        Sprites.Add(Resources.Load<Sprite>("Image/TempIcons/health-bar"));
    }

    public void ShowUI()
    {
        
    }

    public void UpdateUI()
    {
        // �������� �Ⱥ��̰� �ϱ� ����
        foreach (var atk in Attacks)
            atk.SetActive(false);

        //  ��Ʋ�ʵ�� ������ ������ ��
        //  ���� ����?
        //  ��� �ִ� ���Ͱ� ������ ������̸� �Ŀ� ������ ������� �����
        for (int i = 0; i < BattleField.Instance.divisionNum * BattleField.Instance.divisionNum; i++)
        {
            var tempAttack = BattleField.Instance.GetAttack(i);
            if (tempAttack.BattleEffects.Count <= 0)
                continue;

            //  ��ġ�� ������Ʈ �Ѵ�.
            //  ��Ʋ�ʵ忡�� ���� �� �ֳ�? ��ü �Ǵ� ���ݵ�
            Vector3 monsterPos = BattleField.Instance.GetMonsterPos(i);
            //Debug.Log("monsterpos : " + monsterPos);
            var rect = Attacks[i].GetComponent<RectTransform>();
            rect.position = monsterPos;
            //rect.anchoredPosition = monsterPos;

            //UpdateUI(BattleField.Instance.SearchMonster(i));

            //  ǥ���Ѵ�.
            Attacks[i].SetActive(true);
        }
    }

    public void improvedUpdateUI()
    {
        foreach (var atk in Attacks)
            atk.SetActive(false);

        foreach(var mon in BattleField.Instance.monsters)
        {
            var rect = Attacks[mon.Pos].GetComponent<RectTransform>();
            rect.position = BattleField.Instance.GetMonsterPos(mon.Pos);

            UpdateUI(mon);

            Attacks[mon.Pos].SetActive(true);
        }
    }

    //  ���;� �� ������ ��
    public void UpdateUI(Monster monster)
    {
        //foreach (var atk in Attacks)
        //    atk.SetActive(false);

        //  ������ �̹����� ������Ʈ�Ѵ�.
        switch (monster.NowAttack.Type)
        {
            case (IconType.Buff):
                Attacks[monster.Pos].GetComponent<Image>().sprite = Sprites[0];
                break;

            case (IconType.NormalAttack):
                Debug.Log("monster.pos : " + Attacks[monster.Pos]);
                Debug.Log("sprites error? : " + Sprites[1]);
                Attacks[monster.Pos].GetComponent<Image>().sprite = Sprites[1];
                break;
            case (IconType.Shield):
                Attacks[monster.Pos].GetComponent<Image>().sprite = Sprites[2];
                break;
            case (IconType.Recovery):
                Attacks[monster.Pos].GetComponent<Image>().sprite = Sprites[0];
                break;
        }
        //  nowpower ������Ʈ
        Attacks[monster.Pos].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = monster.NowAttack.NowPower.ToString();

        //  ����� ������Ʈ �Ѵ�.
        //  �ؽ�Ʈ ������
        //Attacks[monster.Pos].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ">" + (monster.target.Pos + 1);
        
        // line�뵵 34�� ���� �̸��� ���� �����������
        if (monster.target is PartyMember)
        {
            var startP = BattleField.Instance.GetMonsterPos(monster.Pos);
            //var startP = Attacks[monster.Pos].transform.parent.position;
            var endP = PartyUI.Instance.characterUIs[monster.target.Pos].transform.position;

            
            if(monster.NowAttack.Type != IconType.NormalAttack)
                Attacks[monster.Pos].transform.GetChild(1).GetComponent<AttackLineUI>().SetPoints(Vector3.zero, Vector3.zero);
            else
                Attacks[monster.Pos].transform.GetChild(1).GetComponent<AttackLineUI>().SetPoints(Vector3.zero, endP - startP);
            Debug.Log("attacckUI : updateUI(object)");

        }
    }
}
