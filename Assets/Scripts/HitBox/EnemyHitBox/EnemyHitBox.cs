using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : HitBox
{
    
    private PlayerController playerController;
     
    protected virtual void Start()
    {
        tagName = "Player";
        playerController = GameObject.FindGameObjectWithTag(tagName).GetComponent<PlayerController>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealthSystem playerHealthSystem = other.GetComponent<PlayerHealthSystem>();
        HandleTrigger(other, playerHealthSystem);
        
    }
    protected override void PushForceApply(Collider2D other, Rigidbody2D otherRigidbody)
    {   
        if(playerController != null)
        {
            base.PushForceApply(other, otherRigidbody);
            playerController.applyForce = true;
        }      
       
    }
    protected override void TriggerExitBool()
    {
        base.TriggerExitBool();
        playerController.applyForce = false;
        
    }
    
}
