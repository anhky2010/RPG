using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragStorage : MonoBehaviour, IDropHandler
{

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        if (item == null)
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
            DragHandler.itemBeingDragged.GetComponent<DragHandler>().isBottom = true;
            DragHandler.itemBeingDragged.name = DragHandler.itemBeingDragged.GetComponent<SkillSlot>().skill.skill_name;
            //Destroy(DragHandler.itemBeingDragged.gameObject);
        }

        SkillManagerUI.instance.UpdateSkillList();

    }


}
