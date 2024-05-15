using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : EnemyHitBox
{
    private const float destroyTimeDelay = 0.2f;
    
    protected override void Start()
    {
        base.Start();        
        Destroy(gameObject, destroyTimeDelay);
    }

    

}
