using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : Item
{
    private Rigidbody2D itemRb;
    private const float dropForce = 5f;
    private const float rotationSpeed = 90f;

    
    protected override void Start()
    {
        base.Start();
        itemRb = GetComponent<Rigidbody2D>();
        triggerName = "Player";
        if(itemRb != null && gameObject != null)
        {
            Drop();
        }
        
    }
    private void Update()
    {
        if (gameObject != null)
        {
            Rotate();
        }
    }    
    protected virtual void Rotate()
    {
        transform.Rotate(Vector2.up * rotationSpeed * Time.deltaTime);
    }
    protected virtual void Drop()
    {
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }
}
