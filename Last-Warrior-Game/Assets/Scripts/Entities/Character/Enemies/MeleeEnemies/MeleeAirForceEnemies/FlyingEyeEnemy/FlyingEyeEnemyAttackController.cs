
public class FlyingEyeEnemyAttackController : MeleeEnemyAttackController
{
    private FlyingEyeAnimatorController flyingEyeAnimatorController;
    protected override void Start()
    {
        AttackStartingDistance = 0.5f;
        base.Start();
        flyingEyeAnimatorController = (FlyingEyeAnimatorController)enemyAnimatorController;
    }
}
 