
public class AirForceEnemyMovement : EnemyMovement
{
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        GravityScale(0);
    }
    protected void GravityScale(float gravityScale)
    {
        _rigidbody.gravityScale = gravityScale;
    }
    public void AirForceEnemyGravityScaleWhenDead()
    {
        GravityScale(1f);
    }

}
