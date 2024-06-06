using UnityEngine;
public class Coin : CollectItem,IHandleCollision
{  
    
    private const int coinValue = 10;    
    private GameManager gameManager;   


    protected void Awake()
    {           
        gameManager = FindObjectOfType<GameManager>();
    }

    public void HandleCollision()
    {
       if(playerObject != null)
       {
            audioManager.Play(AudioManager.coinCollectSoundName);
            gameManager._coin += coinValue;
            gameManager.UpdateCoinText();
           
            ItemDestroyed();
       }      
    }  
    
}
