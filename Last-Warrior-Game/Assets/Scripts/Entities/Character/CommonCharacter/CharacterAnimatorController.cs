public class CharacterAnimatorController : AnimatorController
{
   
    private const string deathAnimationBoolName = "Death_Bool";
    private const string hurtAnimationTriggerName = "Take_Hit_Trigger"; 
    public virtual void DeathAnimation()
    {
        SetAnimationBool(deathAnimationBoolName, true);
    }
    public virtual void HurtAnimation()
    {
        SetAnimationTrigger(hurtAnimationTriggerName);
    }
    protected void StartAnimation(string boolName)
    {
        SetAnimationBool(boolName, true);
    }
    protected void StopAnimation(string boolName)
    {
        SetAnimationBool(boolName, false);
    } 

    protected void SetAnimationBool(string boolName, bool boolValue)
    {
        _animator.SetBool(boolName, boolValue);
    }

}
