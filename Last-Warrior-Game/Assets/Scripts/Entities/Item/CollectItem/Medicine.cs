
public class Medicine : CollectItem,IHandleCollision
{
    public int healAmount = 20;
     
    public void HandleCollision()
    {
        if (PlayerController.Instance.playerHealthSystem != null)
        {
            if (PlayerController.Instance.playerHealthSystem.CurrentHealth < PlayerController.Instance.playerHealthSystem.MaxHealth)
            {
                PlayerController.Instance.playerHealthSystem.Heal(healAmount);                
                ItemDestroyed();

            }

        } 
        

    }
}
