﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public GameObject skill_Object;
    public string skill_name = "None";
    public Sprite icon;
    public int skill_Range = 1;
    public int mana_Cost = 1;
    public int damage = 0;
    public float cooldown_Time = 1;
    public float current_cooldown_Time = 1;

    public int animation_Type = 0;
    public float delay_Appear = 0;
    public float delay_Dmg = 0;
    public int times_dmg = 1;
}
