using UnityEngine;
public class PlayerController : Controller
{
    private const string horizontalInputName = "Horizontal";
    private PlayerMovement playerMovement;   
    private PlayerAttackController playerAttackController;
    [HideInInspector]
    public PlayerHealthSystem playerHealthSystem;
    public static PlayerController Instance;    
    [HideInInspector]
    public bool applyForce = false;
    private float horizontalInput;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    
    private void Update()
    {
        if (CheckCurrentHealtAndApplyForce())
        {
            CheckInput();
        }
    }
    private void FixedUpdate()
    {     
        // Player Move
        if (CheckCurrentHealtAndApplyForce())
        {
            playerMovement.Move(horizontalInput);
        }
    }
    private void CheckInput()
    {
        if (CheckDeadState())
        {
            horizontalInput = Input.GetAxisRaw(horizontalInputName);
            // Player Jumping
            if (Input.GetKeyDown(KeyCode.W) && !playerMovement.isDashing )
            {
                JumpBehaviour();              
                               
            }            
            // Player Dashing
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                DashBehaviour();
            }
            // Player Attacking
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttackBehaviour();

            }

        }    
       
    }
    private void JumpBehaviour()
    {
        if (IsOnGround())
        {
            playerMovement.Jumping();
            playerMovement.StopJumping();
        }        
    }
   
    private void AttackBehaviour()
    {
        if (IsOnGround())
        {
            playerAttackController.Attacking();
        }
    }
   
    private void DashBehaviour()
    {
        if (IsOnGround())
        {
            playerMovement.Dash(horizontalInput);
        }
       
    }
    private bool IsOnGround()
    {
        return playerMovement.groundCheck.IsOnGround;
    }
    
    private bool CheckCurrentHealtAndApplyForce()
    {
        return playerHealthSystem.CurrentHealth > 0 && !applyForce;
    }
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        playerMovement = (PlayerMovement)characterMovement;
        playerHealthSystem = (PlayerHealthSystem)healthSystem;
        playerAttackController = (PlayerAttackController)characterAttackController;
    }

}
