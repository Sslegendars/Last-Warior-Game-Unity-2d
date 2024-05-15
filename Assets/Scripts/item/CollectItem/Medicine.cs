using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : CollectItem
{
    public int healAmount = 20;
    private const string healSound = "PlayerHeal";
    protected PlayerHealthSystem playerHealthSystem;
   
    protected override void Start()
    {       
        base.Start();        
        if (playerObject != null)
        {
            playerHealthSystem = playerObject.GetComponent<PlayerHealthSystem>();
        }       
    }    
    protected override void HandleCollision()
    {
        if (playerHealthSystem != null)
        {
            if (playerHealthSystem.currentHealth < playerHealthSystem.maxHealth)
            {
                itemSound = healSound;
                ItemSounds();
                playerHealthSystem.Heal();                
                ItemDestroyed();

            }

        } 
        

    }
}
