using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemyAnimatorController : EnemyAnimatorController
{
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        SetAnimationDuration(0.65f, 0.75f);
    }
}
