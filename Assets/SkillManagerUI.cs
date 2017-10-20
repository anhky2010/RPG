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
    List<SkillSlot> list_B = new List<SkillSlot>();
    void Start()
    {
        slot = itemsParent.GetComponentsInChildren<SkillSlot>();
        UpdateSkillBoardManager();
        UpdateSkillList();

        for (int i = 0; i < 7; i++) list_B.Add(emptySkillSlot);
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
                LBeginSlot[i] = tempList[number];
                number++;
            }
        }
        SkillManager.instance.AddSkillToList(LBeginSlot);
    }

    List<SkillSlot> ListNoDups(List<SkillSlot> _list)
    {
        List<SkillSlot> list_A = _list;

        int pos = 0;
        int count = 0;
        for (int i = 0; i < list_A.Count; i++)
        {
            for (int j = 0; j < list_B.Count; j++)
            {
                if (list_B[j].gameObject.name == list_A[i].gameObject.name)
                {
                    count++;
                }
            }
            if (count < 1)
            {
                list_B[pos] = list_A[i];
                pos++;
                count = 0;
            }
        }
        return list_B;

    }

}
