using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnDamage : MonoBehaviour
{
    [SerializeField] private GameObject playerBurnParticle;

    private bool isBurning = false;
    private PlayerHealthSystem playerHealthSystem;

    private const int damagePerSecond = 5;

    private void Start()
    {  
        playerBurnParticle.SetActive(false);        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealthSystem = other.GetComponent<PlayerHealthSystem>();
            if(playerHealthSystem != null)
            {
                isBurning = true;
                InvokeRepeating(nameof(DealDamage), 1f, 1f);
                Invoke(nameof(StopBurning), 3f);
            }
            else
            {
                playerBurnParticle.SetActive(false);
            }
            
        }
    }

    private void DealDamage()
    {
        if (playerHealthSystem != null && isBurning)
        {
            playerHealthSystem.SetDamage(damagePerSecond);
            // Fire Particle nesnesini aktif hale getirme
            if (playerBurnParticle != null)
            {
                playerBurnParticle.SetActive(true);
                if(playerHealthSystem.currentHealth > 0)
                {
                    FindObjectOfType<AudioManager>()?.Play("FireParticle");
                }
               
            }
           
        }
    }

    private void StopBurning()
    {
        isBurning = false;
        CancelInvoke(nameof(DealDamage));

        // Fire Particle nesnesini pasif hale getirme
        if(playerBurnParticle != null)
        {
            playerBurnParticle.SetActive(false);
            FindObjectOfType<AudioManager>()?.Stop("FireParticle");
        }
       
    }
}
