using UnityEngine;

public class HitBox : MonoBehaviour
{
    [Header("HitBox Settings")]
    public int damageAmount;
    public float pushForce;
    [SerializeField]
    protected Transform _transform;
    protected string tagName;
    private bool damageApplied = false;
    protected CharacterHealthSystem characterHealthSystem;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        characterHealthSystem = other.GetComponent<CharacterHealthSystem>();
        HandleTrigger(other);
    }

    protected void HandleTrigger(Collider2D other)
    {
        if (other.CompareTag(tagName))
        {
            Rigidbody2D otherRigidbody = other.GetComponent<Rigidbody2D>();

            if (!damageApplied && otherRigidbody != null && characterHealthSystem != null)
            {
                ApplyDamageAndPushForce(other, otherRigidbody);
            }
        }
    }

    protected virtual void ApplyDamageAndPushForce(Collider2D other, Rigidbody2D otherRigidbody)
    {
        characterHealthSystem.TakeDamage(damageAmount);

        if (_transform != null)
        {
            PushForceApply(other, otherRigidbody);
        }

        damageApplied = true;
    }

    protected virtual void PushForceApply(Collider2D other, Rigidbody2D otherRigidbody)
    {
        Vector2 pushDirection = (other.transform.position - _transform.position).normalized;
        otherRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagName))
        {
            TriggerExitBool();
        }
    }

    protected virtual void TriggerExitBool()
    {
        damageApplied = false;
    }



}
