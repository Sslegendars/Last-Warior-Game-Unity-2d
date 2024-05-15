using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    private GameManager gameManager;
    private const string healSound = "PlayerHeal";
    private const string hurtSound = "PlayerHurt";

    private const float gameOverCallTimeDelay = 2f;
    protected override void Start()
    {
        base.Start();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }   
    
    protected override void HandleHealVariable()
    {
        Medicine medicineItem = FindObjectOfType<Medicine>();        
        currentHealth += medicineItem.healAmount;
        PlayerSound(healSound);      
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("UpperBound"))
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
            Dead();
        }
    }
    protected override void Dead()
    {
        base.Dead();
        Invoke("CallGameOver", gameOverCallTimeDelay);
    }
    private void CallGameOver()
    {
        gameManager.GameOver();
    }
    protected override void HandeleAnimationTrigger()
    {
        base.HandeleAnimationTrigger();
        PlayerSound(hurtSound);
    }
    private void PlayerSound(string soundName)
    {
        FindAnyObjectByType<AudioManager>()?.Play(soundName);
    }
    public void AddMaxHealth(int spentMoneyAmount)
    {
        if(healthBar != null && gameManager._coin >= spentMoneyAmount && currentHealth > 0)
        {
            int addMaxHealth = 10;
            maxHealth += addMaxHealth;
            healthBar.SetMaxValue(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
    }    

}
