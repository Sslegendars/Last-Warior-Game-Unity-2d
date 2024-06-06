using System.Collections;
using UnityEngine;

public class BossEnemyAttackController : MeleeEnemyAttackController
{
    private BossEnemyAnimatorController bossEnemyAnimatorController;  
    [SerializeField]
    private GameObject _spell;
    private bool canCastSpell = true;    
    public bool CanCastSpell
    {
        get { return canCastSpell; }
    }
    protected override void Start()
    {
        AttackStartingDistance = 1f;
        base.Start();
        bossEnemyAnimatorController = (BossEnemyAnimatorController)enemyAnimatorController;
        SetSpellActive(false);
    }
    public override void Attacking()
    {
        base.IsAttacking();
    }
    public void MagicAttack()
    {
        if (canCastSpell)
        {
            StartCoroutine(MagicAttackCoroutine());
        }
        else
        {
            StopCoroutine(MagicAttackCoroutine());
        }

    }
    public void StopMagicAttack()
    {
        StopCoroutine(MagicAttackCoroutine());
        canCastSpell = true;
    }
    
    private void SetSpellActive(bool isActive)
    {
        _spell.SetActive(isActive);
        
    }
   
    private IEnumerator MagicAttackCoroutine()
    {
        canCastSpell = false;
        yield return StartCoroutine(bossEnemyAnimatorController.FirstSpellCoroutine());        
        SetSpellActive(true);
        yield return StartCoroutine(bossEnemyAnimatorController.SecondSpellCoroutine());        
        SetSpellActive(false);
        yield return StartCoroutine(bossEnemyAnimatorController.ThirdSpellCoroutine());       
        canCastSpell = true;
    }
    
}
