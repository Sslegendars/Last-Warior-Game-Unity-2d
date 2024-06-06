using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemyHitBox : HazardHitBox
{
    protected override void Start()
    {
        base.Start();
        damageAmount = 20;
        pushForce = 20;
    }
}
