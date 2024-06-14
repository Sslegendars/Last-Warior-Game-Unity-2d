using UnityEngine;

public class InfantryEnemyMovement : EnemyMovement
{
    [HideInInspector]
    public GroundCheck groundCheck;
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        groundCheck = GetComponent<GroundCheck>();
    }
    public override void Move(Vector2 lookDirection)
    {
        if (groundCheck.IsOnGround)
        {
            base.Move(lookDirection);
        }
        
    }
}
