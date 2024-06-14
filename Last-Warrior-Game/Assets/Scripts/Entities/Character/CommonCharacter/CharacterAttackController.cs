using UnityEngine;

public class CharacterAttackController : MonoBehaviour
{
    protected bool isAttacking = false; 
    public virtual void Attacking()
    {
        if (!isAttacking)
        {
            IsAttacking();
        }               
       
    }
    protected virtual void IsAttacking()
    {   
        isAttacking = true;      
        
    }
}
