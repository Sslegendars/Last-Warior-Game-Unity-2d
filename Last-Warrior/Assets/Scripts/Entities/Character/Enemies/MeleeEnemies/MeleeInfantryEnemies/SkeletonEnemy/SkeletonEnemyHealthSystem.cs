using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyHealthSystem : EnemyHealthSystem
{
    protected override void InitializeComponents()
    {
        MaxHealth = 100;
        base.InitializeComponents();
        
    }
}
