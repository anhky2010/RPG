using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollAnimation : EnermyAnimation {

    public override void Start()
    {
        base.Start();
        paramDeath = "Death_2";
        paramAttack = "EnermyAttack";
        runningAniName = "runningAniName";

    }

    public override void Update()
    {
        base.Update();
    }
}
