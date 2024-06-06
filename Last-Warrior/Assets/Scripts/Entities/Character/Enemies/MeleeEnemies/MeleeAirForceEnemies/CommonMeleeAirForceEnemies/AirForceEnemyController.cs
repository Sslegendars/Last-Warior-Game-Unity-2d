

public class AirForceEnemyController : MeleeEnemyController
{
    private bool disableCollider = false;
    protected AirForceEnemyMovement airForceEnemyMovement;
    
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        airForceEnemyMovement = (AirForceEnemyMovement)enemyMovement;
    }
    protected override void DisableComponents()
    {              
       
        airForceEnemyMovement.AirForceEnemyGravityScaleWhenDead();
        if (disableCollider)
        {
            base.DisableComponents();
        }
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            disableCollider = true;
        }
    }
}
