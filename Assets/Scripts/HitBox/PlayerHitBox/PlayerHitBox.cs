using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : HitBox
{
    //private EnemyHealthSystem enemyHealthSystem;
    private GameManager gameManager;
    private float addPushForce = 5f;
    private int addDamageAmount = 10;
    
    
    
    // Start is called before the first frame update
    private void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        tagName = "Enemy";
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealthSystem enemyHealthSystem = other.GetComponent<EnemyHealthSystem>();
        
       
        HandleTrigger(other, enemyHealthSystem);
    }
    

    // PauseMenu\PowerUpPanel\DamagePowerUp\DamagePowerUp(Button) OnClikEvent()
    public void AddMaxDamage(int spentMoneyAmount)
    {
        if (gameManager != null)
        {            
            if (gameManager._coin >= spentMoneyAmount)
            {
               
                damageAmount += addDamageAmount;
            }

        }

    }
    // PauseMenu\PowerUpPanel\PushForcePowerUp\PushForcePowerUp(Button) OnClikEvent()
    public void AddMaxPushForce(int spentMoneyAmount)
    {
        
        if (gameManager != null)
        {
            if (gameManager._coin >= spentMoneyAmount)
            {
                
                pushForce += addPushForce;
            }
        }

    }
   


}
