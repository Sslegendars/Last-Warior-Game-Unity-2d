using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{   
    // General variable for items      
    //private Collider2D[] myColliders;
    
    protected GameObject playerObject;
    protected internal string itemSound;
    protected internal string triggerName = "Player";
   
    protected virtual void Start()
    {
        
        playerObject = GameObject.FindGameObjectWithTag("Player");
           
    }
   
    protected void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag(triggerName))
        {
            HandleCollision();
        }        
    }
   
    protected virtual void HandleCollision()
    {
        //HandlePlayerCollision method must be implemented in derived classes
    }
   
    protected virtual void ItemDestroyed()
    {
        //Item Collected by Player
        Destroy(gameObject);
    }  
    
    //  Item Movement   
    protected void ItemSounds()
    {
        FindObjectOfType<AudioManager>()?.Play(itemSound);
    }
   
}

