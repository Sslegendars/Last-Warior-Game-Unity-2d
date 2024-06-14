public class EnemyAttackController : CharacterAttackController
{
    protected EnemyAnimatorController enemyAnimatorController;    
    
    private float attackStartingDistance;
    private bool checkAttackRange = false;
    
    private float attackRange;   
    public bool CheckAttackRange
    {
        get{ return checkAttackRange; }
        protected set{checkAttackRange = value;}
    }
    public float AttackRange
    {
        get{ return attackRange; }
        protected set{attackRange = value;}
    }
    public float AttackStartingDistance
    {
        get{ return attackStartingDistance; }
        protected set{attackStartingDistance = value;}

    }
    protected virtual void Start()
    {
        enemyAnimatorController = GetComponent<EnemyAnimatorController>();
        
    }
    public virtual void StopAttacking()
    {
        CheckAttackRange = false;
        isAttacking = false;
    }


}
