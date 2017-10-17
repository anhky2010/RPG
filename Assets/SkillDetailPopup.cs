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
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        popUpPanel.SetActive(false);
    }




}

