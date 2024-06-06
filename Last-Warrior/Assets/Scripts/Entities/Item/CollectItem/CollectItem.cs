using UnityEngine;

public class CollectItem : Item
{
    private CollectItemMovement collectItemMovement;
       
    protected override void Start()
    {
        base.Start();
        collectItemMovement = GetComponent<CollectItemMovement>();
       
        if( collectItemMovement._rigidbody != null && gameObject != null)
        {
           collectItemMovement.Drop();
        }
        
    }
    private void FixedUpdate()
    {
        if (gameObject != null)
        {
            collectItemMovement.Rotate();
        }
    }    
    
}
