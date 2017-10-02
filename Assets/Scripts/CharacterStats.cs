﻿
using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public static CharacterStats instance;
    public delegate void OnCharacterStatsChanged();
    public OnCharacterStatsChanged onCharacterStatsChanged;

    public int maxHealth = 1;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;
    public Stat speed;

    public virtual void Awake()
    {
        instance = this;
        currentHealth = maxHealth;
         
    } 

    public  void TakeDamage(int dmg)
    {
        dmg -= armor.GetFinalValue();
        dmg = Mathf.Clamp(dmg, 0, int.MaxValue);
        currentHealth -= dmg;
        Debug.Log(transform.name + " takes " + dmg + " damage.");
        if (currentHealth <= 0)
        {
            Die();
        }
        if (onCharacterStatsChanged != null)
        {
            onCharacterStatsChanged.Invoke();
        }
    }

    public virtual void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public virtual void Die()
    {

    }
}
