
public class SkeletonEnemyHitBox : HazardHitBox
{
    protected override void Start()
    {
        base.Start();
        damageAmount = 15;
        pushForce = 15;
    }
}
