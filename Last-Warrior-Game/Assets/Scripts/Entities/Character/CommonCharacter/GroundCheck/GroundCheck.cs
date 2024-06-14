using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isOnGround = false;
    public bool IsOnGround
    {
        get{ return isOnGround;}
        
    }    
    protected void OnCollisionEnter2D(Collision2D other)
    {
        UpdateGroundedState(other, true);
    }
    protected void OnCollisionExit2D(Collision2D other)
    {
        UpdateGroundedState(other, false);
    }
    protected void UpdateGroundedState(Collision2D other, bool grounded)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isOnGround = grounded;
        }
    }
}
