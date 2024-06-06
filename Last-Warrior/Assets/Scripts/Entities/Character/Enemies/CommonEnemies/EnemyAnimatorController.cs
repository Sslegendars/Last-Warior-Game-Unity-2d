using System.Collections;
using UnityEngine;

public class EnemyAnimatorController : CharacterAnimatorController
{
    private const string idleBoolName = "Idle_Bool";
    private const string runBoolName = "Run_Bool";
    private const string firstAttackAnimationName = "Attack_Bool_1";
    private const string secondAttackAnimationName = "Attack_Bool_2";
   
    protected float attackAnimationDuration;    
    protected float idleAnimationDuration;
    //  Handle Idle Animation
    
    protected void SetAnimationDuration(float attackDuration, float idleDuration)
    {
        attackAnimationDuration = attackDuration;
        idleAnimationDuration = idleDuration;
    }
    public virtual void StartIdleAnimation()
    {
        //_animator.SetBool("Idle_Bool", true);
        StartAnimation(idleBoolName);

    }
    public virtual void StopIdleAnimation()
    {
        //_animator.SetBool("Idle_Bool", false);
        StopAnimation(idleBoolName);
       
    }
    //  Handele Run Animation
    public virtual void StartRunAnimation()
    {
        StartAnimation(runBoolName);
    }
    public virtual void StopRunAnimation()
    {        
        StopAnimation(runBoolName);
    }
    //  Handle First Attack Animation
    public virtual void StartFirstAttackAnimation()
    {
        StartAnimation(firstAttackAnimationName);
    }
    public virtual void StopFirstAttackAnimation()
    {
        StopAnimation(firstAttackAnimationName);
    }
    //  Handle Second Attack Animation
    public virtual void StartSecondAttackAnimation()
    {
        StartAnimation(secondAttackAnimationName);
    }
    public virtual void StopSecondAttackAnimation()
    {
        StopAnimation(secondAttackAnimationName);
    }
    public virtual IEnumerator AttackAnimationCoroutine()
    {        
        StopRunAnimation();
        StopIdleAnimation();
        StartFirstAttackAnimation();
        yield return new WaitForSeconds(attackAnimationDuration);
        StopFirstAttackAnimation();
        StartIdleAnimation();
        yield return new WaitForSeconds(idleAnimationDuration);
        StopIdleAnimation();
        StartSecondAttackAnimation();
        yield return new WaitForSeconds(attackAnimationDuration);
        StopSecondAttackAnimation();
        StartIdleAnimation();
        yield return new WaitForSeconds(idleAnimationDuration);
        StopIdleAnimation();
    }   
    
    
}
