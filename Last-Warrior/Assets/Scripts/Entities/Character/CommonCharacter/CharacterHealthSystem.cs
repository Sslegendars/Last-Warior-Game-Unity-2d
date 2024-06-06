using UnityEngine;

public class CharacterHealthSystem : MonoBehaviour,IDamageable
{
    public HealthBar healthBar;
    private int maxHealth;
    [SerializeField]
    private int currentHealth;
    protected CharacterAnimatorController characterAnimatorController;

    protected internal float deathTime = 3.0f;
    private bool isDead = false;

    public bool IsDead
    {
        get { return isDead; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        protected set
        {
            maxHealth = value;
            if (healthBar != null)
            {
                healthBar.SetMaxValue(maxHealth);
            }
        }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        protected set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            if (healthBar != null)
            {
                healthBar.SetHealth(currentHealth);
            }
            if (currentHealth <= 0 && !isDead)
            {
                Dead();
            }
        }
    }

    private void Start()
    {
        InitializeComponents();
    }
    protected virtual void InitializeComponents()
    {
        characterAnimatorController = GetComponent<CharacterAnimatorController>();
        CurrentHealth = MaxHealth;
    }

    public virtual void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            if (characterAnimatorController != null)
            {
                SetDamage(damageAmount);
                CharacterHurtSituation();
            }

            if (currentHealth <= 0)
            {
                Dead();
            }
        }
    }

    public void SetDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
    }

    protected virtual void Dead()
    {
        if (characterAnimatorController != null && !isDead)
        {
            characterAnimatorController.DeathAnimation();
            isDead = true;
        }

        Destroy(gameObject, deathTime);
    }   

    protected virtual void CharacterHurtSituation()
    {
        characterAnimatorController.HurtAnimation();
    }   

    


}
