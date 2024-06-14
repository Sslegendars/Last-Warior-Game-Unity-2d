
public class MushroomEnemyController : InfantryEnemyController
{
    private MushroomEnemyMovement mushroomEnemyMovement;
    private MushroomEnemyAttackController mushroomEnemyAttackController;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        mushroomEnemyMovement = (MushroomEnemyMovement)infantryEnemyMovement;
        mushroomEnemyAttackController = (MushroomEnemyAttackController)enemyAttackController;

    }
}
