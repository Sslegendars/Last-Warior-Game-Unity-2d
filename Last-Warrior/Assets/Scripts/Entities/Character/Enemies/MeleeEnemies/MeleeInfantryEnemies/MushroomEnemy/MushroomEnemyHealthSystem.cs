using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyHealthSystem : EnemyHealthSystem
{
    protected override void InitializeComponents()
    {
        MaxHealth = 80;
        base.InitializeComponents();
        
    }
}
