using UnityEngine;

public class PlayerHitBox : HitBox
{
    private GameManager gameManager;
    private float addPushForce = 5f;
    private int addDamageAmount = 10;  
      
    private void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        tagName = "Enemy";
    }
    public void AddMaxDamage(int spentMoneyAmount)
    {
        if (gameManager != null && gameManager._coin >= spentMoneyAmount)
        {
            damageAmount += addDamageAmount;
        }

    }
    public void AddMaxPushForce(int spentMoneyAmount)
    {
        
        if (gameManager != null && gameManager._coin >= spentMoneyAmount)
        {
            pushForce += addPushForce;
        }

    }  


}
