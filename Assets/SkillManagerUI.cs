using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SkillManagerUI : MonoBehaviour
{
    public static SkillManagerUI instance;
    public Transform itemsParent;
    public Transform useSlotParent;
    public GameObject SkillBoardManager;
    public GameObject PopUpDetail;

    [SerializeField] SkillSlot emptySkillSlot;
    SkillSlot[] slot;
    SkillSlot[] useableSlot;
    bool isInitial = false;

    // Use this for initialization
    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    void Start()
    {
        slot = itemsParent.GetComponentsInChildren<SkillSlot>();
        useableSlot = useSlotParent.GetComponentsInChildren<SkillSlot>();
        UpdateSkillBoardManager();
        useableSlot = new SkillSlot[7];
        UpdateSkillList();


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

    void UpdateSkillBoardManager()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (i < SkillManager.instance.ListSkill.Count)
            {
                slot[i].AddItem(SkillManager.instance.ListSkill[i]);
            }
            else slot[i].RemoveSlot();
        }

    }
    public void UpdateSkillList()
    {
        var childrenCount = useSlotParent.childCount;

        for (int i = 0; i < childrenCount; i++)
        {
            if (useSlotParent.GetChild(i).GetComponentInChildren<SkillSlot>() != emptySkillSlot)
            {
                useableSlot[i] = useSlotParent.GetChild(i).GetComponentInChildren<SkillSlot>();
            }
            if (useSlotParent.GetChild(i).GetComponentInChildren<SkillSlot>() == null)
            {
                useableSlot[i] = emptySkillSlot;
            }
        }
        SkillManager.instance.AddSkillToList(useableSlot);
    }

}
