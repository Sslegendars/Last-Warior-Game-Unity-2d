using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InfantryEnemy : Enemy
{
    private bool isOnGround = false;
    private const string groundTagName = "Ground";

    private void OnCollisionEnter2D(Collision2D other)
    {
        UpdateGroundedState(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        UpdateGroundedState(other, false);
    }

    protected override void Move(Vector2 lookDirection)
    {
        if (isOnGround)
        {
            base.Move(lookDirection);
        }
       
    }

    protected override void Attack()
    {
        if (isOnGround)
        {
            base.Attack();
        }           
        
    }

    private void UpdateGroundedState(Collision2D other, bool grounded)
    {
        if (other.collider.CompareTag(groundTagName))
        {
            isOnGround = grounded;
        }
    }
    


}
