using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : EnermyAnimation {

    public override void Start()
    {
        base.Start();
        paramDeath = "Death_2";
        paramAttack = "EnermyAttack";
        runningAniName = "UD_infantry_07_attack_A";

    }

    public override void Update()
    {
        base.Update();
    }
}
