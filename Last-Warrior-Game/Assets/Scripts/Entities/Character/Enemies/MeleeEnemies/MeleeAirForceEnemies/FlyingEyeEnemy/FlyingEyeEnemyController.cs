
public class FlyingEyeEnemyController : AirForceEnemyController
{
    private FlyingEyeEnemyMovement flyingEyeEnemyMovement;
    private FlyingEyeEnemyAttackController flyingEyeEnemyAttackController;
    
   
   
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        flyingEyeEnemyMovement = (FlyingEyeEnemyMovement)airForceEnemyMovement;
        flyingEyeEnemyAttackController = (FlyingEyeEnemyAttackController)meleeEnemyAttackController;
        
       
    }
    
}
