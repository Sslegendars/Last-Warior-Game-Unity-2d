using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeEnemyHealthSystem : EnemyHealthSystem
{
    protected override void InitializeComponents()
    {
        MaxHealth = 70;
        base.InitializeComponents();
        
    }

}
