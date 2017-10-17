using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlot : MonoBehaviour
{
    Skill skill;
    public Image icon;


    public void AddItem(Skill newitem)
    {
        skill = newitem;
        icon.enabled = true;
        icon.sprite = skill.icon;
    }

    public void RemoveSlot()
    {
        skill = null;
        icon.sprite = null;
        icon.enabled = false;

    }


}
