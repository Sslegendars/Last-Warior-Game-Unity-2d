
public class FlyingEyeEnemyMovement : AirForceEnemyMovement
{
    private FlyingEyeAnimatorController flyingEyeAnimatorController;
    
    protected override void InitializeComponents()
    {        
        base.InitializeComponents();
        flyingEyeAnimatorController = (FlyingEyeAnimatorController)enemyAnimatorController;
        SetScale(2f, 2f);
        Speed = 2f;
    }


}
