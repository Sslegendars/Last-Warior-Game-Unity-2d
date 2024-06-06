
public class Medicine : CollectItem,IHandleCollision
{
    public int healAmount = 20;
    protected PlayerHealthSystem playerHealthSystem;
   
    protected override void Start()
    {       
        base.Start();        
        if (playerObject != null)
        {
            playerHealthSystem = playerObject.GetComponent<PlayerHealthSystem>();
        }       
    }    
    public void HandleCollision()
    {
        if (playerHealthSystem != null)
        {
            if (playerHealthSystem.CurrentHealth < playerHealthSystem.MaxHealth)
            {
                playerHealthSystem.Heal();                
                ItemDestroyed();

            }

        } 
        

    }
}
