using UnityEngine;

public class EnemyMovement : CharacterMovement
{
    protected EnemyAnimatorController enemyAnimatorController;
   
    private void MovingRigidbody(Vector2 lookDirection)
    {
        Vector2 moveDirection = Vector2.Lerp(_rigidbody.velocity, lookDirection * Speed, Time.fixedDeltaTime);
        _rigidbody.velocity = moveDirection;
    }
    public float DistanceToTargetObject(Transform targetObject)
    {
        float distanceToTargetObject = Vector2.Distance(transform.position, targetObject.position);
        return distanceToTargetObject;
    }   
    public virtual void Move(Vector2 lookDirection)
    {
        FaceFlipping(lookDirection);
        enemyAnimatorController.StopIdleAnimation();
        enemyAnimatorController.StartRunAnimation();
        MovingRigidbody(lookDirection);        
    }    
    public void StopMoving()
    {
        _rigidbody.velocity = Vector2.zero;
        enemyAnimatorController.StopRunAnimation();
    }
    public Vector2 LookDirection(Transform lookToObject)
    {
        Vector2 lookDirection = (lookToObject.position - transform.position).normalized;
        return lookDirection;
    }
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        enemyAnimatorController = (EnemyAnimatorController)characterAnimatorController;
    }

}
