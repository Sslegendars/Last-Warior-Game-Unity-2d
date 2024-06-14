using UnityEngine;

public class PlayerHitBox : HitBox
{
    private float addPushForce = 5f;
    private int addDamageAmount = 10;  
      
    private void Start()
    {        
       tagName = "Enemy";
    }
    public void AddMaxDamage(int spentMoneyAmount)
    {
        if (CheckGameManager(spentMoneyAmount))
        {
            damageAmount += addDamageAmount;
        }

    }
    public void AddMaxPushForce(int spentMoneyAmount)
    {
        
        if (CheckGameManager(spentMoneyAmount))
        {
            pushForce += addPushForce;
        }

    } 
    private bool CheckGameManager(int spentMoneyAmount)
    {
        return GameManager.Instance != null && GameManager.Instance._coin >= spentMoneyAmount;
    }


}
