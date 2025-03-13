using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSkillUI : MonoBehaviour
{
    List<WitchSkill> witchSkills = new List<WitchSkill>();
    List<ActiveSlotUI> slots = new List<ActiveSlotUI>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) 
            slots.Add(transform.GetChild(i).GetComponent<ActiveSlotUI>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSkill(WitchSkill skill)
    {
        if (witchSkills.Count < 3)
            witchSkills.Add(skill);

        slots[witchSkills.Count - 1].Skill = skill;
        slots[witchSkills.Count - 1].SetImage();


        return;
    }

    public void AddSkill()
    {
        WitchSkill skill = new WitchSkill();

        if (witchSkills.Count < 3)
            witchSkills.Add(skill);

        slots[witchSkills.Count - 1].Skill = skill;
        slots[witchSkills.Count - 1].SetImage();


        return;
    }

    public void Show()
    {

    }
}
