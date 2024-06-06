using UnityEngine;

public class PlayerHealthSystem : CharacterHealthSystem
{
    private GameManager gameManager;
    private AudioManager audioManager;    
   
    private const float gameOverCallTimeDelay = 2f;  
    protected override void InitializeComponents()
    {
        MaxHealth = 100;
        base.InitializeComponents();
        
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

    }
    public void Heal()
    {
        if (healthBar != null && CurrentHealth < MaxHealth)
        {
            Medicine medicineItem = FindObjectOfType<Medicine>();
            CurrentHealth += medicineItem.healAmount;            
            audioManager.Play(AudioManager.playerHealSoundName);
            
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
        gameManager.GameOver();
    }
    protected override void CharacterHurtSituation()
    {
        base.CharacterHurtSituation();
        audioManager.Play(AudioManager.playerHurtSoundName);
    }

    public void AddMaxHealth(int spentMoneyAmount)
    {
        if (healthBar != null && gameManager._coin >= spentMoneyAmount && CurrentHealth > 0)
        {
            int addMaxHealth = 10;
            MaxHealth += addMaxHealth;
            healthBar.SetMaxValue(MaxHealth);
            healthBar.SetHealth(CurrentHealth);
        }
    }

}
