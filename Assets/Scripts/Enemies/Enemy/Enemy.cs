using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [Header("Movement Settings")]
    [SerializeField] private float _speed;

    [Header("Scale Settings")]
    [SerializeField] 
    protected float scaleX = 2.0f;
    [SerializeField]
    protected float scaleY = 2.0f;

    [Header("Attack Settings")]
    [SerializeField] 
    private float attackDistanceRange = 1f;
    [SerializeField] 
    protected float attackDelay = 0.5f;

    [Header("Idle Animation Settings")]
    [SerializeField] 
    protected float idleDuration = 1f;

    // Animation strings  Name
    private const string attackAnim1 = "Attack_Bool_1";
    private const string attackAnim2 = "Attack_Bool_2";
    private const string idleAnim = "Idle_Bool";
    private const string runAnim = "Run_Bool";

    // Components
    protected Rigidbody2D _rigidbody;
    protected Animator _animator;
    private Collider2D _collider;

    // Axess Scripts and Object.
    private GameObject targetToPlayer;
    private PlayerHealthSystem playerHealthSystem;    
    protected EnemyHealthSystem enemyHealthSystem;   

    // Move variable
    public float distanceToPlayer;
    private Vector2 lookDirection;
    private const float _distance = 30f;

    public bool isAttacking = false;
    private float hurtBoolDelay = 1.5f;

    private float secondAttackDistanceRange;
    private bool secondAttackDistanceBool = false;   

    protected virtual void Start()
    {
        InitializeComponents();
        secondAttackDistanceRange = attackDistanceRange + 1f;       
    }
    private void FixedUpdate()
    {
        if (enemyHealthSystem.hurtBool)
        {
            StopCoroutine(AttackCoroutine());
            StartCoroutine(HurtBoolCoroutine());
        }
        else
        {
            if (targetToPlayer != null && playerHealthSystem != null && playerHealthSystem.currentHealth > 0 && enemyHealthSystem.currentHealth > 0 )
            {
                lookDirection = (targetToPlayer.transform.position - transform.position).normalized;
                distanceToPlayer = Vector2.Distance(transform.position, targetToPlayer.transform.position);               
                Condition();               
                
            }
            else
            {
                DisableComponents();
                SetAnimationBools(false, false, true, false);
            }
        }
       

       
       
    }   
    //  Attack() and Move() condition
    private void Condition()
    {

        if (MoveToPlayerCondition() >= distanceToPlayer)
        {
            if (CanCastSpell())
            {
                if (distanceToPlayer > attackDistanceRange && !secondAttackDistanceBool )
                {
                    Move(lookDirection);

                }
                else
                {
                    if(distanceToPlayer <= secondAttackDistanceRange)
                    {
                        StopMoving();
                        Attack();
                    }
                    else
                    {
                        StopCoroutine(AttackCoroutine());
                        secondAttackDistanceBool = false;
                    }
                   

                }
            }                

        }
        else
        {
            //  BossEnemy.cs SpellCoroutine();
            MagicCoroutine();
        }


    }
    private IEnumerator HurtBoolCoroutine()
    {        
        SetAnimationBools(false, false, true, false);               
        yield return new WaitForSeconds(hurtBoolDelay);
        enemyHealthSystem.hurtBool = false;
    }  
    protected virtual bool CanCastSpell()
    {
        return true;
        // Override SubClass
        // BossEnemy.cs
    }
   
    protected virtual float MoveToPlayerCondition()
    {
        float moveToPlayerDistance;
        moveToPlayerDistance = _distance;
        return moveToPlayerDistance;
        //  Derivered Child class
        //  BossEnemy.cs

    }
    protected virtual void MagicCoroutine()
    {    
        //  Another enemy don't Have this method.
        //  Derivered Child Class
        //  BossEnemy.cs
    }
    
    protected virtual void Attack()
    {
        if(playerHealthSystem.currentHealth > 0)
        {
            if (!isAttacking)
            {
                
                StartCoroutine(AttackCoroutine());
            }           
            
        }
        else
        {
            StopCoroutine(AttackCoroutine());
            SetAnimationBools(false, false, true, false);
        }
    }
    protected void StopMoving()
    {
        _rigidbody.velocity = Vector2.zero;
    }
    protected virtual void Move(Vector2 lookDirection)
    {
        Vector2 moveDirection = Vector2.Lerp(_rigidbody.velocity, lookDirection * _speed, Time.fixedDeltaTime);
        _rigidbody.velocity = moveDirection;

        SetAnimationBools(false, false, false, true);
        FaceFlipping(lookDirection);


    }
    protected virtual void FaceFlipping(Vector2 lookDirection)
    {
        
        if(lookDirection.x > 0)
        {
            SetFaceScale(scaleX, scaleY);
        }
        else if(lookDirection.x < 0)
        {
            SetFaceScale(-scaleX,scaleY);
        }
    }
    protected virtual void SetFaceScale(float scaleX, float scaleY)
    {       
        transform.localScale = new Vector2(scaleX, scaleY);
    }
    public virtual void DisableComponents()
    {
        _rigidbody.simulated = false;
        _collider.enabled = false;
        // Ovveride AirForceEnemy.cs
    }
    protected virtual IEnumerator AttackCoroutine()
    {
        secondAttackDistanceBool = true;
        isAttacking = true;
        SetAnimationBools(true, false, false, false);
        yield return new WaitForSeconds(attackDelay);
        SetAnimationBools(false, false, true, false);
        yield return new WaitForSeconds(idleDuration);
        SetAnimationBools(false, true, false, false);
        yield return new WaitForSeconds(attackDelay);
        SetAnimationBools(false, false, true, false);
        yield return new WaitForSeconds(idleDuration);
        SetAnimationBools(false, false, false, false);
        isAttacking = false;
        
    }
    protected virtual void SetAnimationBools(bool attack1, bool attack2, bool idle, bool move)
    {
        _animator.SetBool(attackAnim1, attack1);
        _animator.SetBool(attackAnim2, attack2);
        _animator.SetBool(idleAnim, idle);
        _animator.SetBool(runAnim, move);      
    }
    private void InitializeComponents()
    {
        targetToPlayer = GameObject.FindGameObjectWithTag("Player");
        playerHealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        enemyHealthSystem = GetComponent<EnemyHealthSystem>();
    }



}
