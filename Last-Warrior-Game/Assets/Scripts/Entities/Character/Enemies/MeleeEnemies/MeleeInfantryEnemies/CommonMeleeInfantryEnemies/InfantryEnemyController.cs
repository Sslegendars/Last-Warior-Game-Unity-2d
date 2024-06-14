
public class InfantryEnemyController : MeleeEnemyController
{
    protected InfantryEnemyMovement infantryEnemyMovement;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        infantryEnemyMovement = (InfantryEnemyMovement)enemyMovement;
    }    
    protected override void HandleEnemyBehavior()
    {
        if (infantryEnemyMovement.groundCheck.IsOnGround)
        {
            base.HandleEnemyBehavior();
        }
        
    }
   
}
