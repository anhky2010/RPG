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
            SkillManagerUI.instance.UpdateSkillList();
        }
    }
}
