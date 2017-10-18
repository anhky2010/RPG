using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public List<Skill> ListSkill;
    public Skill[] ListSpawnSkill;

    [SerializeField] Skill emptySkill;
    [SerializeField] GameObject SkillSpawnStorage;

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
        ListSpawnSkill = new Skill[7];
    }
    public void CastSkill(Vector3 _pos)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject temp = Instantiate(ListSpawnSkill[0].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject temp = Instantiate(ListSpawnSkill[1].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject temp = Instantiate(ListSpawnSkill[2].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject temp = Instantiate(ListSpawnSkill[3].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameObject temp = Instantiate(ListSpawnSkill[4].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GameObject temp = Instantiate(ListSpawnSkill[5].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            GameObject temp = Instantiate(ListSpawnSkill[6].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }

    }

    public void AddSkillToList(SkillSlot[] _skillSlot)
    {
        for (int i = 0; i < _skillSlot.Length; i++)
        {
            if (_skillSlot[i] != emptySkill)
            {
                ListSpawnSkill[i] = _skillSlot[i].skill;
            }
            else ListSpawnSkill[i] = emptySkill;

        }

    }


}
