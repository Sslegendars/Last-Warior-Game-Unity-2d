

public class SkeletonEnemyAttackController : MeleeEnemyAttackController
{
    private SkeletonEnemyAnimatorController skeletonEnemyAnimatorController;
    protected override void Start()
    {
        AttackStartingDistance = 1f;
        base.Start();
        skeletonEnemyAnimatorController = (SkeletonEnemyAnimatorController)enemyAnimatorController;
    }
}
