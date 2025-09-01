using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{

    public List<Sprite> sprites;

    public Sprite basicSprite;

    // Start is called before the first frame update
    void Start()
    {
        sprites = new List<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        //Debug.Log("characters num : " + PlayerData.Instance.characters.Count);

        //int i = 0;
        //foreach (var character in PlayerData.Instance.characters)

        for (int i = 0; i < PlayerData.Instance.characters.Count; i++) 
        {
            transform.GetChild(i + 1).GetComponent<Image>().sprite = PlayerData.Instance.characters[i].image;

            //Debug.Log("child" + i + " : ");
            //sprites.Add(PlayerData.Instance.characters[i].image);

            //i++;
        }

        for (int i = PlayerData.Instance.characters.Count; i < 4; i++)
        {
            transform.GetChild(i + 1).GetComponent<Image>().sprite = basicSprite;
        }

        transform.GetChild(6).GetComponent<Image>().sprite = GachaSystem.Instance.tempMember.image;
        sprites.Add(GachaSystem.Instance.tempMember.image);
    }
}
