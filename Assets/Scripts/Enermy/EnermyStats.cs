using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyStats : CharacterStats
{
    public delegate void OnDoDamage(int _dmg);
    public OnDoDamage onDoDamage;

    public override void Awake()
    {
        base.Awake();
    }
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
    public override void TakeDamage(int _dmg)
    {
        base.TakeDamage(_dmg);

        if (onDoDamage != null)
        {
            onDoDamage.Invoke(dmgGetSubArmor);

        }
    }
}
