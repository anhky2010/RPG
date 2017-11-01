using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyStats : CharacterStats
{
    public delegate void OnDoDamage(int _dmg);
    public OnDoDamage onDoDamage;
    private EnermyAnimation enermyAnimation;
    public override void Awake()
    {
        base.Awake();
    }
    public void Start()
    {
        enermyAnimation = this.gameObject.GetComponent<EnermyAnimation>();
    }
    public override void Die()
    {
        base.Die();
        enermyAnimation.DeathAnimation();
        Destroy(gameObject, 3f);
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
