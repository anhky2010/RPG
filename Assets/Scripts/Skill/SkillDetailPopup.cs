using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SkillDetailPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject popUpPanel;



    public void OnPointerEnter(PointerEventData eventData)
    {
        popUpPanel.SetActive(true);
        popUpPanel.transform.position = this.transform.position + new Vector3(50, 150, 0);
        Text[] list_Text = SkillManagerUI.instance.PopUpDetail.GetComponentsInChildren<Text>();
        SkillSlot skill_Slot = this.gameObject.GetComponent<SkillSlot>();
        if (skill_Slot.skill != null)
        {

            list_Text[0].text = skill_Slot.skill.skill_name;
            list_Text[1].text = skill_Slot.skill.damage.ToString();
            list_Text[2].text = skill_Slot.skill.skill_Range.ToString();
        }
        else
        {

            list_Text[0].text = "None";
            list_Text[1].text = "None";
            list_Text[2].text = "None";
        }

    }


    public void OnPointerExit(PointerEventData eventData)
    {
        popUpPanel.SetActive(false);
    }

    private void GetSkillInformation()
    {

    }




}

