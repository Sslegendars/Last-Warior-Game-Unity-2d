using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    protected Animator _animator;
    void Awake()
    {
        InitializeComponents();
    }
    protected void SetAnimationTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }    
    protected virtual void InitializeComponents()
    {
        _animator = GetComponent<Animator>();
    }
}
