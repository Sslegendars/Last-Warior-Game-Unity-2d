using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBurnDamageHitBox : BossEnemyHitBox
{
    [SerializeField]
    private GameObject playerBurnParticle;
    private const int damagePerSecond = 5;
    private bool isBurning = false;
    private AudioManager audioManager;

    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        pushForce = 0;
        playerBurnParticle.SetActive(false);
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    protected override void ApplyDamageAndPushForce(Collider2D other, Rigidbody2D otherRigidbody)
    {
        if (playerHealthSystem != null)
        {
            base.ApplyDamageAndPushForce(other, otherRigidbody);
            StartBurning();
        }
        else
        {
            StopBurning();
        }
    }

    private void StartBurning()
    {
        isBurning = true;
        playerBurnParticle.SetActive(true);
        InvokeRepeating(nameof(DealDamage), 1f, 1f);
        Invoke(nameof(StopBurning), 3f);
    }
    private void StopBurning()
    {
        isBurning = false;
        CancelInvoke(nameof(DealDamage));
        playerBurnParticle.SetActive(false);
        audioManager.Stop(AudioManager.playerFireParticleSoundName);
    }

    private void DealDamage()
    {
        if (playerHealthSystem != null && isBurning)
        {
            playerHealthSystem.SetDamage(damagePerSecond);

            if (playerBurnParticle != null && playerHealthSystem.CurrentHealth > 0)
            {
                audioManager.Play(AudioManager.playerFireParticleSoundName);
            }
        }
    }

    
}
