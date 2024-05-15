using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirForceEnemy : Enemy
{
    
    protected override void Start()
    {
        base.Start();        
        
        GravityScale(0);
    }   
    private void GravityScale(float gravityScale)
    {
        _rigidbody.gravityScale = gravityScale;
    }
    public override void DisableComponents()
    {
        
        GravityScale(1f);
    }

}
