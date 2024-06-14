using System.Collections;
using UnityEngine;
public class EnemyHealthSystem : CharacterHealthSystem
{   
    [Header("Drop item settings")]
    [SerializeField]
    protected GameObject[] itemDrops;

    private bool hasDroppedItem = false;
    private bool _stunned = false;
    private float leftBound = -30f;
    private float rightBound = 30f;
    private float groundBound = -5f;
    protected float waitStunnedTrueToFalse = 1.5f;
    private EnemyAnimatorController enemyAnimatorController;

    public bool Stunned
    {
        get { return _stunned; }
    }    
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        enemyAnimatorController = (EnemyAnimatorController)characterAnimatorController;
    }
    protected override void Dead()
    {
        if (!hasDroppedItem)
        {
            ItemDrop();
            hasDroppedItem = true;
        }
        
        base.Dead();       
       

    }
    private void Update()
    {
        OutOfBound();
    }

    protected virtual void ItemDrop()
    {
        
        if(itemDrops.Length > 0)
        {
            int randomIndex = Random.Range(0, itemDrops.Length);
            GameObject itemToDrop = itemDrops[randomIndex];

            Instantiate(itemToDrop, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            
        }               
    }    
    protected override void CharacterHurtSituation()
    {
        base.CharacterHurtSituation();
        _stunned = true;
    }   
   
    private void OutOfBound()
    {
        if(gameObject.transform.position.x < leftBound 
            || gameObject.transform.position.x > rightBound 
            || gameObject.transform.position.y < groundBound)
        {
            Destroy(gameObject);
        }
    }
    public void StartHurtBoolTrueToFalseCoroutine()
    {
        StartCoroutine(HurtWithAnimationCoroutine());
    }
    protected IEnumerator HurtWithAnimationCoroutine()
    {
        enemyAnimatorController.StartIdleAnimation();
        yield return new WaitForSeconds(waitStunnedTrueToFalse);
        _stunned = false;
    }

}
