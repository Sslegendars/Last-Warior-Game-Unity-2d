using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyHitBox : HazardHitBox
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        damageAmount = 10;
        pushForce = 10;
    }

    
}
