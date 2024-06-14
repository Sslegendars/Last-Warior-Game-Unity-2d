using System.Collections;
public class PlayerAttackController : CharacterAttackController
{
    protected PlayerAnimatorController playerAnimatorController;
    private void Start()
    {
        playerAnimatorController = GetComponent<PlayerAnimatorController>();     
    }
    protected override void IsAttacking()
    {
        base.IsAttacking();
        StartCoroutine(AttackWithAnimationCoroutine());
    }
    private IEnumerator AttackWithAnimationCoroutine()
    {
        AudioManager.Instance.Play(AudioManager.playerAttackSoundName);
        yield return StartCoroutine(playerAnimatorController.AttackAnimationCoroutine());
        isAttacking = false;        
    }
}
