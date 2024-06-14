using UnityEngine;

public class Controller : MonoBehaviour
{
    protected CharacterHealthSystem healthSystem;
    protected CharacterMovement characterMovement;
    protected CharacterAttackController characterAttackController;   
    private void Start()
    {
        InitializeComponents();
    }
    protected virtual void InitializeComponents()
    {
        healthSystem = GetComponent<CharacterHealthSystem>();
        characterMovement = GetComponent<CharacterMovement>();
        characterAttackController = GetComponent<CharacterAttackController>();        
    }
    protected bool CheckDeadState()
    {
        return !healthSystem.IsDead;
    }
}
