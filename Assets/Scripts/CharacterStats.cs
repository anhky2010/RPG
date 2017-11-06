
using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public static CharacterStats instance;
    public delegate void OnCharacterStatsChanged();
    public OnCharacterStatsChanged onCharacterStatsChanged;

    public bool alive;
    public int maxHealth = 1;
    public int currentHealth { get; private set; }
    public int maxMana = 1;
    public int currentMana { get; private set; }

    public Stat damage;
    public Stat armor;
    public Stat speed;
    public Stat attackRange;
    public Stat attackSpeed;
    public float AttackSize = 0;

    public float curDCAtt = 0;
    protected int dmgGetSubArmor = 0;
    public virtual void Awake()
    {
        alive = true;
        instance = this;
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    public virtual void TakeDamage(int _dmg)
    {
        _dmg -= armor.GetFinalValue();
        _dmg = Mathf.Clamp(_dmg, 0, int.MaxValue);
        currentHealth -= _dmg;
        dmgGetSubArmor = _dmg;
        Debug.Log(transform.name + " takes " + _dmg + " damage.");

        if (currentHealth <= 0)
        {
            if (alive == true)
            {
                Die();
            }
        }
        if (onCharacterStatsChanged != null)
        {
            onCharacterStatsChanged.Invoke();
        }

    }
    public virtual void Update()
    {
    }

    public virtual void Die()
    {
        alive = false;
    }

    void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,attackRange.GetFinalValue());


    }
}
