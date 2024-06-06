
public class BossEnemyPushForceHitBox : BossEnemyHitBox
{
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        pushForce = 45;
    }
}
