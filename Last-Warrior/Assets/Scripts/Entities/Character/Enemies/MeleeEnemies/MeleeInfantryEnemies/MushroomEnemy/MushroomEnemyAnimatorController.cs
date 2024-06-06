using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyAnimatorController : EnemyAnimatorController
{
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        SetAnimationDuration(0.5f, 1);
    }
}
