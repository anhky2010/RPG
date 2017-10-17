using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManagerUI : MonoBehaviour
{

    public Transform itemsParent;
    public Transform useSlotParent;
    public GameObject SkillBoardManager;
    public GameObject PopUpDetail;
    Inventory inventory;
    SkillSlot[] slot;
    SkillSlot[] useableSlot;
    bool isInitial = false;
    // Use this for initialization
    void Start()
    {
        slot = itemsParent.GetComponentsInChildren<SkillSlot>();
        useableSlot = useSlotParent.GetComponentsInChildren<SkillSlot>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            SkillBoardManager.SetActive(!SkillBoardManager.activeSelf);
            PopUpDetail.SetActive(false);
        }

        if (isInitial == false)
        {
            SkillBoardManager.SetActive(!SkillBoardManager.activeSelf);
            PopUpDetail.SetActive(false);
            isInitial = true;
        }
    }
    void UpdateUI()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (i < SkillManager.instance.ListSkill.Count)
            {
                slot[i].AddItem(SkillManager.instance.ListSkill[i]);
            }
            else slot[i].RemoveSlot();
        }

        for (int i = 0; i < useableSlot.Length; i++)
        {
            if (i < SkillManager.instance.ListUseSkill.Count)
            {
                useableSlot[i].AddItem(SkillManager.instance.ListUseSkill[i]);
            }
            else useableSlot[i].RemoveSlot();
        }
    }

}
