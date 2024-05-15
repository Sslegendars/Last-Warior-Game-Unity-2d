using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : HealthSystem
{   
    [Header("Drop item settings")]
    [SerializeField]
    private GameObject[] itemDrops;

    [HideInInspector]
    public bool hurtBool = false;

    private float leftBound = -13f;
    private float rightBound = 30f;

    private float groundBound = -5f;

    protected override void Dead()
    {    
        
        base.Dead();
        DisabledComponentsDead();
        ItemDrop();

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
            //GameObject itemToDrop = itemDrops[randomIndex];

            Instantiate(itemDrops[randomIndex], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
               
    }
    protected override void HandeleAnimationTrigger()
    {
        base.HandeleAnimationTrigger();
        hurtBool = true;
    }
    protected virtual void DisabledComponentsDead()
    {
        Enemy enemy = GetComponent<Enemy>();
        enemy.DisableComponents();
        // Override subclass AirforceEnemyHealthSystem.cs
    }
    private void OutOfBound()
    {
        if(gameObject.transform.position.x < leftBound || gameObject.transform.position.x > rightBound || gameObject.transform.position.y < groundBound)
        {
            Destroy(gameObject);
        }
    }

}
