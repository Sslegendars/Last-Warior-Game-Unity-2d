
public class SkeletonEnemyMovement : InfantryEnemyMovement
{
    private SkeletonEnemyAnimatorController skeletonEnemyAnimatorController;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        skeletonEnemyAnimatorController = (SkeletonEnemyAnimatorController)enemyAnimatorController;
        SetScale(1.5f,1.5f);
        Speed = 5f;
    }

}
