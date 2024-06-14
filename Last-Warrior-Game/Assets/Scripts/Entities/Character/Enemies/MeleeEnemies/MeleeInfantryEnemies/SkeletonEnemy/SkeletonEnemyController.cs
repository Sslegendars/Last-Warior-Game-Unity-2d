
public class SkeletonEnemyController : InfantryEnemyController
{
    private SkeletonEnemyMovement skeletonEnemyMovement;
    private SkeletonEnemyAttackController skeletonEnemyAttackController;

    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        skeletonEnemyMovement = (SkeletonEnemyMovement)infantryEnemyMovement;
        skeletonEnemyAttackController = (SkeletonEnemyAttackController)enemyAttackController;
    }
}
