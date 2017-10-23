using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManagerUI : MonoBehaviour
{
    public static SkillManagerUI instance;
    public GameObject itemsParent;
    public GameObject SkillBoard;
    public GameObject SkillBoardManager;
    public GameObject CountDownSkillBoard;
    public GameObject PopUpDetail;
    double a = 1;
    [SerializeField] SkillSlot emptySkillSlot;
    SkillSlot[] slot;
    Text[] list_CDText;
    Image[] list_CDIcon;

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
        list_CDText = CountDownSkillBoard.GetComponentsInChildren<Text>();
        list_CDIcon = CountDownSkillBoard.GetComponentsInChildren<Image>();

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

        }
        if (isInitial == false)
        {
            SkillBoardManager.SetActive(!SkillBoardManager.activeSelf);
            PopUpDetail.SetActive(false);
            isInitial = true;
        }
        CoolDownDisplay();

    }

    void UpdateSkillBoardManager()
    {
        var ss = GetComponentsInChildren<DragHandler>();
        for (int i = 0; i < slot.Length; i++)
        {
            if (i < SkillManager.instance.List_Skill.Count)
            {
                slot[i].AddItem(SkillManager.instance.List_Skill[i]);
            }
            else slot[i].RemoveSlot();

            if (slot[i].skill == null)
            {
                Destroy(ss[i]);
            }

        }
    }

    public void UpdateSkillList()
    {
        SkillSlot[] LBeginSlot = new SkillSlot[7];
        for (int i = 0; i < LBeginSlot.Length; i++)
        {
            LBeginSlot[i] = emptySkillSlot;
        }

        SkillSlot[] LGetSkillSlot = SkillBoard.GetComponentsInChildren<SkillSlot>();
        //  List<SkillSlot> tempList = LGetSkillSlot.ToList<SkillSlot>();

        //  tempList = ListNoDups(tempList);
        int number = 0;
        for (int i = 0; i < LBeginSlot.Length; i++)
        {
            if (SkillBoard.transform.GetChild(i).GetComponentInChildren<SkillSlot>() != null)
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
    private void CoolDownDisplay()
    {

        for (int i = 0; i < SkillManager.instance.List_SpawnSkill.Length; i++)
        {
            a = SkillManager.instance.List_SpawnSkill[i].current_cooldown_Time
                / SkillManager.instance.List_SpawnSkill[i].cooldown_Time;
            a = System.Math.Round(a, 2);
            list_CDIcon[i + 1].fillAmount = (float)a;

            if (SkillManager.instance.List_SpawnSkill[i].current_cooldown_Time > 0)
            {
                list_CDText[i].text = SkillManager.instance.List_SpawnSkill[i].current_cooldown_Time.ToString();

            }
            else
            {
                list_CDText[i].text = " ";
                // list_CDIcon[i].fillAmount = 0;
            }
        }

    }

}
