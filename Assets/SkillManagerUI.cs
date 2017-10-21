using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
public class SkillManagerUI : MonoBehaviour
{
    public static SkillManagerUI instance;
    public GameObject itemsParent;
    public GameObject useSlotParent;
    public GameObject SkillBoardManager;
    public GameObject PopUpDetail;

    [SerializeField] SkillSlot emptySkillSlot;
    SkillSlot[] slot;

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
        UpdateSkillBoardManager();
        UpdateSkillList();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (DragHandler.itemBeingDragged != null)
            {
                Destroy(DragHandler.itemBeingDragged);

                DragHandler.itemBeingDragged = null;
            }
            PopUpDetail.SetActive(false);
            SkillBoardManager.SetActive(!SkillBoardManager.activeSelf);

            // DragHandler.itemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = true;
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
        SkillSlot[] LBeginSlot = new SkillSlot[7];
        for (int i = 0; i < LBeginSlot.Length; i++)
        {
            LBeginSlot[i] = emptySkillSlot;
        }

        SkillSlot[] LGetSkillSlot = useSlotParent.GetComponentsInChildren<SkillSlot>();
        List<SkillSlot> tempList = LGetSkillSlot.ToList<SkillSlot>();

        tempList = ListNoDups(tempList);
        int number = 0;
        for (int i = 0; i < LBeginSlot.Length; i++)
        {
            if (useSlotParent.transform.GetChild(i).GetComponentInChildren<SkillSlot>() != null)
            {
                LBeginSlot[i] = LGetSkillSlot[number];
                number++;
            }
        }
        SkillManager.instance.AddSkillToList(LBeginSlot);
    }

    List<SkillSlot> ListNoDups(List<SkillSlot> _list)
    {

        for (int i = 0; i < _list.Count; i++)
        {
            for (int j = (_list.Count - 1); j > i; j--)
            {
                if (_list[i].skill.skill_name == _list[j].skill.skill_name)
                {
                    _list.RemoveAt(j);
                }
            }
        }

        return _list;


    }

}
