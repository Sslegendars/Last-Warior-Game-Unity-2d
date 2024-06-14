using System.Collections;
public class MeleeEnemyAttackController : EnemyAttackController
{   

    protected override void Start()
    {
        base.Start();
        AttackRange = AttackStartingDistance + 1f;
    }
    protected override void IsAttacking()
    {
        base.IsAttacking();
        StartCoroutine(AttackWithAnimationCoroutine());
    }
    public override void StopAttacking()
    {
        StopCoroutine(AttackWithAnimationCoroutine());
        base.StopAttacking();
        
    }
    private IEnumerator AttackWithAnimationCoroutine()
    {
        CheckAttackRange = true;
        yield return StartCoroutine(enemyAnimatorController.AttackAnimationCoroutine());
        CheckAttackRange = false;
        isAttacking = false;
    }
}
