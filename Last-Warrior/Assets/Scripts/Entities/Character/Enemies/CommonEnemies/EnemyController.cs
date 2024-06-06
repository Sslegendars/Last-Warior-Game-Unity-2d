using UnityEngine;

public class EnemyController : Controller
{    
    protected Collider2D enemyCollider;
    protected EnemyMovement enemyMovement;
    protected EnemyHealthSystem enemyHealthSystem;
    protected EnemyAttackController enemyAttackController;

    protected GameObject playerObject;
    protected PlayerHealthSystem playerHealthSystem;
    protected EnemyAnimatorController enemyAnimatorController;
    protected Vector2 lookDirection;
    protected float distanceToPlayer;    

    private void FixedUpdate()
    {
        HandleDistanceToPlayerAndLookDirection();
        if (!enemyHealthSystem.Stunned)
        {
            if (IsPlayerAndEnemyAlive())
            {
                HandleEnemyBehavior();

            }
            else
            {
                DisableComponents();
            }

        }
        else
        {
            HandleStunnedState();
        }
    }
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        enemyMovement = (EnemyMovement)characterMovement;
        enemyHealthSystem = (EnemyHealthSystem)healthSystem;
        enemyAttackController = (EnemyAttackController)characterAttackController;
        enemyAnimatorController = GetComponent<EnemyAnimatorController>();
        enemyCollider = GetComponent<Collider2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerHealthSystem = playerObject.GetComponent<PlayerHealthSystem>();
        }       
        
    }
    protected virtual void HandleEnemyBehavior()
    {
        if (distanceToPlayer > enemyAttackController.AttackStartingDistance && !enemyAttackController.CheckAttackRange)
        {
            
            HandleMovementBehavior();
        }
        else
        {
            
            HandleAttackBehavior();
        }
    }
    protected void HandleMovementBehavior()
    {
        enemyMovement.Move(lookDirection);
        
    }
    private void HandleDistanceToPlayerAndLookDirection()
    {
        HandleLookDirection();
        HandleDistanceToPlayer();
    }
    
    protected void HandleAttackBehavior()
    {
        distanceToPlayer = enemyMovement.DistanceToTargetObject(playerObject);
        if (distanceToPlayer <= enemyAttackController.AttackRange)
        {   
            
            if (!enemyAttackController.CheckAttackRange)
            {
                
                enemyMovement.StopMoving();
                enemyAttackController.Attacking();               
            }           
            
        }
        else
        {
            
            enemyAttackController.StopAttacking(); 
            
        }
    }
    protected virtual void HandleStunnedState()
    {
        //  if the enemy gets hit, play Idle Animation, wait until the delay is over
        enemyMovement.StopMoving();
        enemyHealthSystem.StartHurtBoolTrueToFalseCoroutine();
    }       
    protected bool IsPlayerAndEnemyAlive()
    {
        return playerObject != null && playerHealthSystem != null &&
               playerHealthSystem.CurrentHealth > 0 && enemyHealthSystem.CurrentHealth > 0;
    }
    
    protected virtual void DisableComponents()
    {
        enemyCollider.enabled = false;
        enemyMovement._rigidbody.simulated = false;       
    }
    
    private Vector2 HandleLookDirection()
    {
        return lookDirection = enemyMovement.LookDirection(playerObject);
    }
    private float HandleDistanceToPlayer()
    {
        return distanceToPlayer = enemyMovement.DistanceToTargetObject(playerObject);
    }

}
