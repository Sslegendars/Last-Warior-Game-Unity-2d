
public class BombExplosion : HazardHitBox
{
    
    private const float destroyTimeDelay = 0.2f;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        Destroy(gameObject, destroyTimeDelay);
    }
    


}
