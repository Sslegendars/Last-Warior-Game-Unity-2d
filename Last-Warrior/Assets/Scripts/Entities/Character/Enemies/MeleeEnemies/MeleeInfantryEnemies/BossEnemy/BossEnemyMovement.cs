
public class BossEnemyMovement : InfantryEnemyMovement
{
    private BossEnemyAnimatorController bossEnemyAnimatorController;
    private const float moveToPlayerDistance = 7f;
    
    public float MoveToPlayerDistance
    {
        get{ return moveToPlayerDistance; }
    }
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        bossEnemyAnimatorController = (BossEnemyAnimatorController)enemyAnimatorController;
        SetScale(-2, 2);
        Speed = 7f;
    }


}
