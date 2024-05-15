using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : EvilItem
{   
    [Header("Enemy Spawn Object")]
    [SerializeField] 
    private GameObject skeletonEnemy;

    private int currentHit = 0;   
    private bool hitApplied = false;   
    private const int maxHits = 5;  
  
    protected override void Start()
    {
        base.Start();       
        StartCoroutine(DestroyGameObject());
        triggerName = "Player_HitBox";
    }   
    protected override void HandleCollision()
    {
        if (!hitApplied)
        {
            currentHit++;
            if (currentHit >= maxHits)
            {
                StopCoroutine(DestroyGameObject());
                ItemDestroyed();               
            }

            _animator.SetTrigger("Hit_Trigger");
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
            
            itemSound = "Grave";
            ItemSounds();
            Instantiate(skeletonEnemy, transform.position, Quaternion.identity);
            ItemDestroyed();
        }
        
       
    }
}

