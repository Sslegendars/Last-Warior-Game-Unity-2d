using UnityEngine;

public class Item : MonoBehaviour
{   
    protected string triggerName = "Player";
    private IHandleCollision interfaceHandleCollision;   
   
    protected virtual void Start()
    {
        InitializeComponents();         
    }   
    protected void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag(triggerName) && interfaceHandleCollision != null)
        {
            interfaceHandleCollision.HandleCollision();
        }        
    }  

    protected virtual void ItemDestroyed()
    {
        Destroy(gameObject);
    }

    protected virtual void InitializeComponents()
    {
        interfaceHandleCollision = GetComponent<IHandleCollision>();
    }
}

