using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    [SerializeField] List<Skill> ListSkill;
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
            GameObject temp = Instantiate(ListSkill[0].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject temp = Instantiate(ListSkill[1].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject temp = Instantiate(ListSkill[2].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject temp = Instantiate(ListSkill[3].skill_Object, _pos, Quaternion.identity);
            temp.transform.parent = SkillSpawnStorage.transform;
        }
    }


}
