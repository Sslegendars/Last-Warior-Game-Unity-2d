using UnityEngine;

public class Item : MonoBehaviour
{   
    protected GameObject playerObject;
    protected string triggerName = "Player";
    protected AudioManager audioManager;
    private IHandleCollision interfaceHandleCollision;
    
   
    protected virtual void Start()
    {
        
        playerObject = GameObject.FindGameObjectWithTag("Player");
        audioManager = FindAnyObjectByType<AudioManager>();
        interfaceHandleCollision = GetComponent<IHandleCollision>();
           
    }
   
    protected void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag(triggerName))
        {
            interfaceHandleCollision.HandleCollision();
        }        
    }  

    protected virtual void ItemDestroyed()
    {
        Destroy(gameObject);
    }
       
   
}

