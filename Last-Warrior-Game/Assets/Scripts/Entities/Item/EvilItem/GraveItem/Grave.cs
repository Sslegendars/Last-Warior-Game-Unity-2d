using System.Collections;
using UnityEngine;

public class Grave : EvilItem,IHandleCollision
{   
    [Header("Enemy Spawn Object")]
    [SerializeField] 
    private GameObject skeletonEnemy;

    private int currentHit = 0;   
    private bool hitApplied = false;   
    private const int maxHits = 5;
    private GraveAnimator graveAnimator;
  
    protected override void Start()
    {
        base.Start();        
        StartCoroutine(DestroyGameObject());
        
    }   
    public void HandleCollision()
    {
        if (!hitApplied)
        {
            currentHit++;
            if (currentHit >= maxHits)
            {
                StopCoroutine(DestroyGameObject());
                ItemDestroyed();
            }

            graveAnimator.TakeHitAnimation();
            hitApplied = true;
        }
        
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(triggerName))
        {
            hitApplied = false;
        }
    }  
    IEnumerator DestroyGameObject()
    {
        destroyDelay = 10f;
        yield return new WaitForSeconds(destroyDelay);
        
        if(currentHit < maxHits)
        {

            AudioManager.Instance.Play(AudioManager.graveSoundName);
            Instantiate(skeletonEnemy, transform.position, Quaternion.identity);
            ItemDestroyed();
        }       
       
    }
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        graveAnimator = GetComponent<GraveAnimator>();
        triggerName = "Player_HitBox";
    }
}

