using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemyHealthSystem : EnemyHealthSystem
{
    protected override void InitializeComponents()
    {
        MaxHealth = 120;
        base.InitializeComponents();
        
    }
}
