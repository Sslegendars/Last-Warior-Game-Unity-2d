using UnityEngine;

public class PlayerHealthSystem : CharacterHealthSystem
{   

    private const float gameOverCallTimeDelay = 2f;  
    protected override void InitializeComponents()
    {
        MaxHealth = 100;
        base.InitializeComponents();
        
        

    }
    public void Heal(int healAmount)
    {
        if (healthBar != null && CurrentHealth < MaxHealth)
        {
            CurrentHealth += healAmount;
            AudioManager.Instance.Play(AudioManager.playerHealSoundName);
        }
        else
        {
            CurrentHealth = MaxHealth;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("UpperBound"))
        {
            CurrentHealth = 0;
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
        GameManager.Instance.GameOver();
    }
    protected override void CharacterHurtSituation()
    {
        base.CharacterHurtSituation();
        AudioManager.Instance.Play(AudioManager.playerHurtSoundName);
    }

    public void AddMaxHealth(int spentMoneyAmount)
    {
        if (healthBar != null && GameManager.Instance._coin >= spentMoneyAmount && CurrentHealth > 0)
        {
            int addMaxHealth = 10;
            MaxHealth += addMaxHealth;
            healthBar.SetMaxValue(MaxHealth);
            healthBar.SetHealth(CurrentHealth);
        }
    }

}
