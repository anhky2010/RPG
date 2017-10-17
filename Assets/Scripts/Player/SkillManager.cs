using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public List<Skill> ListSkill;
    public List<Skill> ListUseSkill;
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



    public void CastSkill(Vector3 _pos)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject temp = Instantiate(ListUseSkill[0].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject temp = Instantiate(ListUseSkill[1].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject temp = Instantiate(ListUseSkill[2].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject temp = Instantiate(ListUseSkill[3].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameObject temp = Instantiate(ListUseSkill[4].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GameObject temp = Instantiate(ListUseSkill[5].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            GameObject temp = Instantiate(ListUseSkill[6].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }

    }


}
