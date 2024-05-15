using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [HideInInspector]
    public bool applyForce = false;
    
    private Rigidbody2D _rigidbody;    
    private Animator _animator;   
    private PlayerHealthSystem playerHealthSystem;
    private AudioManager audioManager; 
     
    // Player Movement Settings
    private const float jumpForce = 25f;    
    private const float _speed = 5f;
    private const float dashSpeed = 15f;
    private const float dashDuration = 0.5f;
    private const float dashEndDuration = 1f;
    private bool isOnGround = true;
    private bool isDashing = false;
    private bool facingRight = true;
    // Player Attack Animation Settings
    private bool isAttacking = false;
    private const float attackAnimationDelay = 0.8f;
    // Strings Variable
    private const string dashAnimation = "Dash_Bool";
    private const string isJumpingAnimation = "IsJumping";
    private const string attakTriggerAnimation = "Attack_Trigger";
    private const string horizontalýnput = "Horizontal";
    // Sound String Name
    private const string jumpSound = "Jump";
    private const string attackSound = "PlayerAttack";
    private const string dashSound = "Dash";  
       
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        playerHealthSystem = GetComponent<PlayerHealthSystem>();
        
    }
    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void FixedUpdate()
    {        
        if (playerHealthSystem.currentHealth > 0 && !applyForce)
        {
            Move();
        }
    }

    private void Update()
    {
        if (playerHealthSystem.currentHealth > 0 && !applyForce)
        {
            CheckInput();           
        }


    }
    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw(horizontalýnput);
        _animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        if (!isDashing)
        {
            _rigidbody.velocity = new Vector2(horizontalInput * _speed, _rigidbody.velocity.y);
            if (horizontalInput != 0 && (horizontalInput > 0 && !facingRight || horizontalInput < 0 && facingRight))
            {
                FaceFlipping();
            }
        }
        else
        {
            _rigidbody.velocity = new Vector2(horizontalInput * dashSpeed, _rigidbody.velocity.y);
        }

    }
    private void CheckInput()
    {   
        
        if (isOnGround && Input.GetKeyDown(KeyCode.W) && !isDashing)
        {
            Jump();
        }
        // Player Dash
        if (isOnGround && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(DashCoroutine(Input.GetAxisRaw(horizontalýnput)));
        }

        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            Attack();          
            
        }
    }
   
    private void Jump()
    {
        PlayerSound(jumpSound);
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isOnGround = false;
        PlayerSetAnimationBool(isJumpingAnimation, true);
    }
    private void FaceFlipping()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        facingRight = !facingRight;
    }
    private IEnumerator DashCoroutine(float direction)
    {           
        isDashing = true;       
        PlayerSound(dashSound);       
        PlayerSetAnimationBool(dashAnimation, true);
        _rigidbody.velocity = new Vector2(direction * dashSpeed, _rigidbody.velocity.y);
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;                 
        PlayerSetAnimationBool(dashAnimation, false);
        yield return new WaitForSeconds(dashEndDuration);        
    }  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") )
        {
            isOnGround = true;           
            PlayerSetAnimationBool(isJumpingAnimation, false);
        }       
    }
    private void Attack()
    {
        if (!isAttacking)
        {
            StartCoroutine(WaitAttackAnimation());
        }

    }
    private IEnumerator WaitAttackAnimation()
    {
        isAttacking = true;
        _animator.SetTrigger(attakTriggerAnimation);
        PlayerSound(attackSound);
        yield return new WaitForSeconds(attackAnimationDelay);
        isAttacking = false;
    }  
       
    private void PlayerSound(string sound)
    {
        audioManager.Play(sound);        
    }
    private void PlayerSetAnimationBool(string boolName, bool animationBool)
    {
        _animator.SetBool(boolName, animationBool);
    }  
        
}


