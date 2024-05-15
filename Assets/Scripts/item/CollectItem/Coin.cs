using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : CollectItem
{  
    
    private const int coinValue = 10;    
    private GameManager gameManager;   


    protected void Awake()
    {           
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    protected override void HandleCollision()
    {
       if(playerObject != null)
       {
            itemSound = "CoinCollect";
            ItemSounds();

            gameManager._coin += coinValue;
            gameManager.UpdateCoinText();
           
            ItemDestroyed();
       }      
    }  
    
}
