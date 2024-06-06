using System.Collections;
using UnityEngine;

public class PlayerAnimatorController : CharacterAnimatorController
{
    private const string speedFloatName = "Speed";
    private const string jumpingBoolName = "IsJumping";
    private const string attackTriggerName = "Attack_Trigger";
    private const string dashBoolName = "Dash_Bool";
    private const float jumpingAnimationDuration = 1f;

    private const float attackAnimationDelay = 0.8f;
    public void IdleToRunAnimation(float horizontalInput)
    {
        _animator.SetFloat(speedFloatName, horizontalInput);
    }
    //  Handle Jump Animation
    public void StartJumpingAnimation()
    {       
        StartAnimation(jumpingBoolName);
    } 
    public void StopJumpingAnimation()
    {
        StartCoroutine(StopJumpingAnimationCoroutine());
    }
    private IEnumerator StopJumpingAnimationCoroutine()
    {
        yield return new WaitForSeconds(1f);
        StopAnimation(jumpingBoolName);
    }
    // Handle Dash Animation
    public void StartDashAnimation()
    {
        StartAnimation(dashBoolName);
    }
    public void StopDashAnimation()
    {
        StopAnimation(dashBoolName);
    }

    public void AttackAnimationTrigger()
    {
        SetAnimationTrigger(attackTriggerName);
    }
    public IEnumerator AttackAnimationCoroutine()
    {
        //_animator.SetTrigger(attakTriggerAnimation);
        AttackAnimationTrigger();
        // sound
        yield return new WaitForSeconds(attackAnimationDelay);
    }

}
