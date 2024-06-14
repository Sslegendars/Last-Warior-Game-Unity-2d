
public class MushroomEnemyAttackController : MeleeEnemyAttackController
{
    private MushroomEnemyAnimatorController mushroomEnemyAnimatorController;
    protected override void Start()
    {
        AttackStartingDistance = 0.45f;
        base.Start();
        mushroomEnemyAnimatorController = (MushroomEnemyAnimatorController)enemyAnimatorController;
    }
}
