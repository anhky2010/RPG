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

    void Update()
    {
        for (int i = 0; i < List_SpawnSkill.Length; i++)
        {
            if (List_SpawnSkill[i].current_cooldown_Time > -1)
            {
                List_SpawnSkill[i].current_cooldown_Time -= Time.deltaTime;
            }
        }
    }
    public void CastSkill(Vector3 _pos)
    {
        int _orderSkill = 0;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _orderSkill = 0;
            if (List_SpawnSkill[_orderSkill].current_cooldown_Time > 0) return;
            List_SpawnSkill[_orderSkill].current_cooldown_Time = List_SpawnSkill[_orderSkill].cooldown_Time;
            GameObject temp = Instantiate(List_SpawnSkill[_orderSkill].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = Skill_SpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _orderSkill = 1;
            if (List_SpawnSkill[_orderSkill].current_cooldown_Time > 0) return;
            List_SpawnSkill[_orderSkill].current_cooldown_Time = List_SpawnSkill[_orderSkill].cooldown_Time;
            GameObject temp = Instantiate(List_SpawnSkill[_orderSkill].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = Skill_SpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _orderSkill = 2;
            if (List_SpawnSkill[_orderSkill].current_cooldown_Time > 0) return;
            List_SpawnSkill[_orderSkill].current_cooldown_Time = List_SpawnSkill[_orderSkill].cooldown_Time;
            GameObject temp = Instantiate(List_SpawnSkill[_orderSkill].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = Skill_SpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _orderSkill = 3;
            if (List_SpawnSkill[_orderSkill].current_cooldown_Time > 0) return;
            List_SpawnSkill[_orderSkill].current_cooldown_Time = List_SpawnSkill[_orderSkill].cooldown_Time;
            GameObject temp = Instantiate(List_SpawnSkill[_orderSkill].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = Skill_SpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _orderSkill = 4;
            if (List_SpawnSkill[_orderSkill].current_cooldown_Time > 0) return;
            List_SpawnSkill[_orderSkill].current_cooldown_Time = List_SpawnSkill[_orderSkill].cooldown_Time;
            GameObject temp = Instantiate(List_SpawnSkill[_orderSkill].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = Skill_SpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _orderSkill = 5;
            if (List_SpawnSkill[_orderSkill].current_cooldown_Time > 0) return;
            List_SpawnSkill[_orderSkill].current_cooldown_Time = List_SpawnSkill[_orderSkill].cooldown_Time;
            GameObject temp = Instantiate(List_SpawnSkill[_orderSkill].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = Skill_SpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            _orderSkill = 6;
            if (List_SpawnSkill[_orderSkill].current_cooldown_Time > 0) return;
            List_SpawnSkill[_orderSkill].current_cooldown_Time = List_SpawnSkill[_orderSkill].cooldown_Time;
            GameObject temp = Instantiate(List_SpawnSkill[_orderSkill].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = Skill_SpawnStorage.transform;
        }

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
