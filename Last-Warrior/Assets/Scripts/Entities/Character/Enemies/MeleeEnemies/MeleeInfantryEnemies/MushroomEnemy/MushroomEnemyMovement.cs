
public class MushroomEnemyMovement : InfantryEnemyMovement
{
    private MushroomEnemyAnimatorController mushroomEnemyAnimatorController;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        mushroomEnemyAnimatorController = (MushroomEnemyAnimatorController)enemyAnimatorController;
        SetScale(1.5f, 1.5f);
        Speed = 7f;
    }
}
