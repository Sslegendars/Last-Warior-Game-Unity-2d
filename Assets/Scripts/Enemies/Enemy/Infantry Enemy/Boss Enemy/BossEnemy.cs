using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : InfantryEnemy
{
    // float _scale = -2f;
    [SerializeField]
    private GameObject _spell;

    private bool canCastSpell = true;

    private float castDuration = 1f;
    private float spellDuration = 1f;
    private float waitTime = 1.5f;
    private float moveToPlayerDistance = 7f;

    private const string castSpellName = "Cast_Trigger";    

    protected override void Start()
    {
        base.Start();
        SetSpellActive(false);       
       
    }
    protected override float MoveToPlayerCondition()
    {
        return moveToPlayerDistance;
    }
    private void SetSpellActive(bool isActive)
    {
        _spell.SetActive(isActive);
    }
    protected override void MagicCoroutine()
    {
        if (CanCastSpell() && !enemyHealthSystem.hurtBool)
        {
            StartCoroutine(SpellCoroutine());
        }
        else
        {               
            StopCoroutine(SpellCoroutine());            
        }       
       
    }
    IEnumerator SpellCoroutine()
    {   
        canCastSpell = false;
        SetAnimationBools(false, false, true, false);
        yield return new WaitForSeconds(idleDuration);

        SetAnimationBools(false, false, false, false);
        _animator.SetTrigger(castSpellName);
        yield return new WaitForSeconds(castDuration);

        SetSpellActive(true);
        yield return new WaitForSeconds(spellDuration);

        SetSpellActive(false);
        SetAnimationBools(false, false, true, false);
        yield return new WaitForSeconds(waitTime);
        canCastSpell = true;
        SetAnimationBools(false, false, false, false);
    }
    protected override bool CanCastSpell()
    {
        return canCastSpell;
    }


}

