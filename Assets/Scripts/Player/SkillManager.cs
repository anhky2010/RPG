using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public List<Skill> List_Skill;
    public Skill[] List_SpawnSkill = new Skill[7];
    [SerializeField] Skill emptySkill;
    [SerializeField] GameObject Skill_SpawnStorage;

    public static SkillManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    void Start()
    {
        foreach (var item in List_Skill)
        {
            item.current_cooldown_Time = 0;
        }
    }
    void Update()
    {
        for (int i = 0; i < List_SpawnSkill.Length; i++)
        {
            if (List_SpawnSkill[i].current_cooldown_Time > 0)
            {
                List_SpawnSkill[i].current_cooldown_Time -= Time.deltaTime;
            }
        }

    }
    public bool CastSkill(Vector3 _pos, float _distance, ref int _dmg, ref int _skill_range, ref float _dmg_delay)
    {
        int _orderSkill = 0;
        if (Input.GetKeyDown(KeyCode.Alpha1)) _orderSkill = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) _orderSkill = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) _orderSkill = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) _orderSkill = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha5)) _orderSkill = 4;
        else if (Input.GetKeyDown(KeyCode.Alpha6)) _orderSkill = 5;
        else if (Input.GetKeyDown(KeyCode.Alpha7)) _orderSkill = 6;
        else return false;
        Skill skill_temp = List_SpawnSkill[_orderSkill];
        if (skill_temp.skill_name == emptySkill.skill_name)
        {
            Debug.Log("Chua cai dat ki nang cho phim nay!!");
            ChatBoxManager.instance.EnqueueText("Chua cai dat ki nay cho phim nay!!");
            return false;
        }
        if (skill_temp.current_cooldown_Time > 0)
        {
            Debug.Log("Skill dang cooldown!!");
            ChatBoxManager.instance.EnqueueText("Ki nang dang troi thoi gian hoi!");
            return false;
        }
        if (skill_temp.skill_Range < _distance)
        {
            Debug.Log("Ki nang khong du tam danh!!");
            ChatBoxManager.instance.EnqueueText("Ki nang khong du tam danh!!");
            return false;
        }

        PlayerAnimation.instance.CastSpellAnimation(skill_temp.animation_Type);

        StartCoroutine(CreateSkill(_orderSkill, _pos, skill_temp.delay_Appear));
        _dmg = skill_temp.damage;
        _skill_range = skill_temp.skill_Range;
        _dmg_delay = skill_temp.delay_Dmg;
        return true;
    }

    IEnumerator CreateSkill(int _order, Vector3 _pos, float _delayTime)
    {
        yield return new WaitForSeconds(_delayTime);
        Skill tempSkill = List_SpawnSkill[_order];
        tempSkill.current_cooldown_Time = tempSkill.cooldown_Time;
        GameObject temp = Instantiate(tempSkill.skill_Object, _pos, Quaternion.identity);
        temp.transform.parent = Skill_SpawnStorage.transform;

    }

    public void AddSkillToList(SkillSlot[] _skillSlot)
    {
        for (int i = 0; i < _skillSlot.Length; i++)
        {
            if (_skillSlot[i] != emptySkill)
            {
                List_SpawnSkill[i] = _skillSlot[i].skill;
            }
            if (_skillSlot[i] == null)
            {
                List_SpawnSkill[i] = emptySkill;
            }
        }
    }


}
