
public class GoblinEnemyMovement : InfantryEnemyMovement
{
    private GoblinEnemyAnimatorController goblinEnemyAnimatorController;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        goblinEnemyAnimatorController = (GoblinEnemyAnimatorController)enemyAnimatorController;
        SetScale(2f, 2f);
        Speed = 8f;
    }
}
