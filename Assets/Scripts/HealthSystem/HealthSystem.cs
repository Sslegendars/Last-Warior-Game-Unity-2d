using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{   
    [Header("Health Settings")]
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    protected Animator _animator;

    // Dead condition
    protected internal float deathTime = 3.0f;
    private bool isDead = false;

    // Animation String name 
    private const string hitTrigger = "Take_Hit_Trigger";
    private const string deathBool = "Death_Bool"; 
     
    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxValue(maxHealth);
    }
    public virtual void TakeDamage(int damageAmount)
    {
        SetDamage(damageAmount);

        if (!isDead)
        {
            if (_animator != null)
            {
                HandeleAnimationTrigger();

            }

            if (currentHealth <= 0)
            {
                Dead();
            }
        }
       
    }
    public void SetDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
    }
    protected virtual void Dead()
    {   
        if(_animator != null)
        {
            _animator.SetBool(deathBool, true);
            isDead = true;
        }      
        
        Destroy(gameObject, deathTime);

    }

    public virtual void Heal()
    {
        if(healthBar != null && currentHealth < maxHealth)
        {   
            
            HandleHealVariable();
        }

    } 
    protected virtual void HandeleAnimationTrigger()
    {
        _animator.SetTrigger(hitTrigger);
    }
    protected virtual void HandleHealVariable()
    {
        // will be derived from the subclass.
        // PlayerHealthSystem.cs
        // BossEnemyHealthSystem.cs
    }
    public virtual void StealHealth(int damageDealt)
    {
        // will be derived from the subclass.
        // BossEnemyHealthSystem.cs
    }


}
