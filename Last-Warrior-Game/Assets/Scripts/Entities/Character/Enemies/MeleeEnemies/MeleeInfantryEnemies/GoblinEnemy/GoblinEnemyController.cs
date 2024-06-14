
public class GoblinEnemyController : InfantryEnemyController
{
    private GoblinEnemyMovement goblinEnemyMovement;
    private GoblinEnemyAttackController goblinEnemyAttackController;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        goblinEnemyMovement = (GoblinEnemyMovement)infantryEnemyMovement;
        goblinEnemyAttackController = (GoblinEnemyAttackController)meleeEnemyAttackController;
    }
}
