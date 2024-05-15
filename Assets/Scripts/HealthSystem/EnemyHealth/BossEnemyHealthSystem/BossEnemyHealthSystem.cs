using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyHealthSystem : EnemyHealthSystem
{
    private const float lifePercent = 0.2f;
    private GameManager gameManager;
   
    
    protected override void Start()
    {
        base.Start();
        deathTime = 1f;        
        gameManager = FindObjectOfType<GameManager>();
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
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    public override void StealHealth(int damageDealt)
    {
        int stolenHealth = Mathf.RoundToInt(damageDealt * lifePercent);
        Heal(stolenHealth);
    }
    protected override void Dead()
    {
        gameManager.FinishGame();
        base.Dead();   
              
    }
    protected override void ItemDrop()
    {
        
    }




}
