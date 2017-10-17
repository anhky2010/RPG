using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class test : MonoBehaviour, IDragHandler
{

    //public GameObject item
    //{
    //    get
    //    {
    //        if (transform.childCount > 0)
    //        {
    //            return transform.GetChild(0).gameObject;
    //        }
    //        return null;

    //    }
    //}

    public void OnDrag(PointerEventData eventData)
    {
        // if (item != null)
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
        }
    }


}
