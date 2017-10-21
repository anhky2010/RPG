using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    public Vector3 startPosition;
    Transform startParent;
    public bool isBottom = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        startParent = transform.parent;

        itemBeingDragged = Instantiate(gameObject, transform.position, transform.rotation);
        itemBeingDragged.transform.parent = startParent;
        itemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemBeingDragged.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = true;
        itemBeingDragged.transform.localScale = Vector3.one;

        if (itemBeingDragged.transform.parent == startParent && isBottom == false)
        {
            Destroy(itemBeingDragged.gameObject);
        }

        if (isBottom == true)
        {
            if (itemBeingDragged.transform.parent == startParent)
            {
                Destroy(itemBeingDragged.gameObject);
                Destroy(gameObject);
            }
            if (itemBeingDragged.transform.parent != startParent)
            {
                Destroy(gameObject);
            }

        }
        itemBeingDragged = null;


    }

    void OnDestroy()
    {

        SkillManagerUI.instance.UpdateSkillList();
    }


}
