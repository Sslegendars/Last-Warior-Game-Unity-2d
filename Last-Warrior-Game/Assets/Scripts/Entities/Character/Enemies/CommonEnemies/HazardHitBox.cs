using UnityEngine;

public class HazardHitBox : HitBox
{
    protected virtual void Start()
    {
        InitializeComponents();        
    }

    protected override void PushForceApply(Collider2D other, Rigidbody2D otherRigidbody)
    {
        if (PlayerController.Instance != null)
        {
            base.PushForceApply(other, otherRigidbody);
            PlayerController.Instance.applyForce = true;
        }
    }

    protected override void TriggerExitBool()
    {
        base.TriggerExitBool();
        PlayerController.Instance.applyForce = false;
    }
    protected virtual void InitializeComponents()
    {
        tagName = "Player";        
    }



}
