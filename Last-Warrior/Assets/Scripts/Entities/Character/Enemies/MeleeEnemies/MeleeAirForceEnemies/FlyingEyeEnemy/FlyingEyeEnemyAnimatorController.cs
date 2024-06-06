using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeAnimatorController : EnemyAnimatorController
{
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        SetAnimationDuration(0.75f, 1.2f);
    }
}
