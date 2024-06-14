using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : EnemyController
{
    protected MeleeEnemyAttackController meleeEnemyAttackController;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        meleeEnemyAttackController = (MeleeEnemyAttackController)enemyAttackController;
    }    
    protected override void HandleStunnedState()
    {
        meleeEnemyAttackController.StopAttacking();
        base.HandleStunnedState();
    }
}
