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
            GameObject temp = Instantiate(DragHandler.tempItemBeingDragged,
                                          DragHandler.tempItemBeingDragged.transform.position,
                                          DragHandler.tempItemBeingDragged.transform.rotation);
            temp.transform.SetParent(transform);

            temp.transform.localScale = new Vector3(1, 1, 1);
            temp.GetComponent<DragHandler>().isRoot = false;
            temp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            temp.name = DragHandler.tempItemBeingDragged.name;
            Destroy(DragHandler.tempItemBeingDragged);
            SkillManagerUI.instance.UpdateSkillList();
        }
    }
}
