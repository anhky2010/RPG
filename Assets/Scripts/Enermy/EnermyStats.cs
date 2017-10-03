using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyStats : CharacterStats {

    public override void Awake()
    {
        base.Awake();

    }
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}
