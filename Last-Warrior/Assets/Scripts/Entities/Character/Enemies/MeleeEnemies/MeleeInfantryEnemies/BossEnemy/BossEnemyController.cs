public class BossEnemyController : InfantryEnemyController
{
    private BossEnemyAttackController bossEnemyAttackController;
    private BossEnemyMovement bossEnemyMovement;   
    
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        bossEnemyAttackController = (BossEnemyAttackController)enemyAttackController;
        bossEnemyMovement = (BossEnemyMovement)infantryEnemyMovement;       
        
    }    
    
    protected override void HandleEnemyBehavior()
    {
        if (bossEnemyMovement.groundCheck.IsOnGround)
        {
            if (distanceToPlayer <= bossEnemyMovement.MoveToPlayerDistance)
            {
                if (bossEnemyAttackController.CanCastSpell)
                {
                    base.HandleEnemyBehavior();
                }
            }
            else
            {
                MagicAttackBehavior();
            }

        }
            
    }
    private void EnemyBehaviorGroundCheckCondition()
    {
        if (bossEnemyMovement.groundCheck.IsOnGround)
        {
            EnemyBehaviorCondition();
        }
    }
    private void EnemyBehaviorCondition()
    {
        if (distanceToPlayer <= bossEnemyMovement.MoveToPlayerDistance)
        {
            if (bossEnemyAttackController.CanCastSpell)
            {
                base.HandleEnemyBehavior();
            }
        }
        else
        {
            MagicAttackBehavior();
        }
    }
    private void MagicAttackBehavior()
    {
        bossEnemyMovement.StopMoving();
        bossEnemyAttackController.MagicAttack();
    }   
    protected override void HandleStunnedState()
    {
        bossEnemyAttackController.StopMagicAttack();
        base.HandleStunnedState();       

    }
    protected override void DisableComponents()
    {
        bossEnemyAttackController.StopMagicAttack();
        base.DisableComponents();
       
    }   

}
