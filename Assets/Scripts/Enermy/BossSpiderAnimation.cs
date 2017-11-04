using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiderAnimation : EnermyAnimation
{
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        paramDeath = "Death";
        paramAttack = "paramAttack";
        runningAniName = "Attack";
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
