using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D _rigidbody;
    protected AnimatorController animatorController;  
    private float _speed;
    protected float Speed
    {
         get {return _speed; }
         set { _speed = value; }
    }
    

    
    protected virtual void Awake()
    {        
        InitializeComponents();        
    }
   
   
    protected virtual void InitializeComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<AnimatorController>();        
    }
    
    
   
}
