using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    public static GameObject tempItemBeingDragged;
    public Vector3 startPosition;
    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {

        startPosition = transform.position;
        startParent = transform.parent;

        tempItemBeingDragged = Instantiate(gameObject, transform.position, transform.rotation);
        tempItemBeingDragged.transform.parent = startParent;
        itemBeingDragged = tempItemBeingDragged;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        tempItemBeingDragged.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        // Destroy(tempItemBeingDragged);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //if (transform.parent != startParent)
        {
            transform.position = startPosition;
        }
    }
}
