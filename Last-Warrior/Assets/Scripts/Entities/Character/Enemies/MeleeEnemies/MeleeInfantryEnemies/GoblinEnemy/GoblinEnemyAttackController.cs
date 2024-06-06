
public class GoblinEnemyAttackController : MeleeEnemyAttackController
{
    private GoblinEnemyAnimatorController goblinEnemyAnimatorController;
    
    protected override void Start()
    {
        AttackStartingDistance = 0.8f;
        base.Start();
        goblinEnemyAnimatorController = (GoblinEnemyAnimatorController)enemyAnimatorController;
    }
}
