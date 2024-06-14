using UnityEngine;
public class Coin : CollectItem,IHandleCollision
{  
    
    private const int coinValue = 10;    
    public void HandleCollision()
    {
       if(PlayerController.Instance != null)
       {
            AudioManager.Instance.Play(AudioManager.coinCollectSoundName);
            GameManager.Instance._coin += coinValue;
            GameManager.Instance.UpdateCoinText();
           
            ItemDestroyed();
       }      
    }  
    
}
