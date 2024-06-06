using System.Collections;
public class PlayerAttackController : CharacterAttackController
{
    protected PlayerAnimatorController playerAnimatorController;
    private AudioManager audioManager;
    private const string attackSoundName = "PlayerAttack";
    private void Start()
    {
        playerAnimatorController = GetComponent<PlayerAnimatorController>();
        audioManager = FindAnyObjectByType<AudioManager>();

    }
    protected override void IsAttacking()
    {
        base.IsAttacking();
        StartCoroutine(AttackWithAnimationCoroutine());
    }
    private IEnumerator AttackWithAnimationCoroutine()
    {
        audioManager.Play(attackSoundName);
        yield return StartCoroutine(playerAnimatorController.AttackAnimationCoroutine());
        isAttacking = false;        
    }
}
