using UnityEngine;

public class HazardHitBox : HitBox
{
    protected PlayerController playerController;
    protected PlayerHealthSystem playerHealthSystem;

    protected virtual void Start()
    {
        InitializeComponents();        
    }

    protected override void PushForceApply(Collider2D other, Rigidbody2D otherRigidbody)
    {
        if (playerController != null)
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
    protected virtual void InitializeComponents()
    {
        tagName = "Player";
        playerController = GameObject.FindGameObjectWithTag(tagName).GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerHealthSystem = playerController.GetComponent<PlayerHealthSystem>();

        }
    }



}
