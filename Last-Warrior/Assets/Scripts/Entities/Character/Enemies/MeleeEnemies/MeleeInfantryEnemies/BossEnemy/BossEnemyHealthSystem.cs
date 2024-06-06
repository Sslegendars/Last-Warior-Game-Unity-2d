using UnityEngine;

public class BossEnemyHealthSystem : EnemyHealthSystem
{
    private const float lifePercent = 0.8f;
    private GameManager gameManager;
      
    protected override void InitializeComponents()
    {
        MaxHealth = 500;
        base.InitializeComponents();
        deathTime = 1f;
        gameManager = FindObjectOfType<GameManager>();
        waitStunnedTrueToFalse = 0.8f;
       
    }
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        if(gameObject != null)
        {
            StopAllCoroutines();
        }
       
    }
    public void Heal(int healAmount)
    {
        CurrentHealth += healAmount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }
    public void StealHealth(int damageDealt)
    {
        int stolenHealth = Mathf.RoundToInt(damageDealt * lifePercent);
        if(CurrentHealth < MaxHealth)
        {
            Heal(stolenHealth);
        }
        else
        {
            CurrentHealth = MaxHealth;             
        }
        
    }
    protected override void Dead()
    {
        gameManager.FinishGame();
        base.Dead();   
              
    }
    
   

}
