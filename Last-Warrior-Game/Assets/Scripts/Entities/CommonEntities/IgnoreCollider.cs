using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    protected Collider2D[] myColliders;
    private void Start()
    {
        IgnoreColliders();
    }
    private void IgnoreColliders()
    {
        myColliders = GetComponents<Collider2D>();        
        
        IgnoreCollisionsWithTag("Enemy", LayerMask.NameToLayer("Enemy"));
        IgnoreCollisionsWithTag("Item", LayerMask.NameToLayer("Prop"));
        IgnoreCollisionsWithTag("Player", LayerMask.NameToLayer("Player"));
        
    }

    private void IgnoreCollisionsWithTag(string tag, int layer)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objects)
        {
            if (obj != gameObject && obj.layer == layer)
            {
                Collider2D[] objColliders = obj.GetComponents<Collider2D>();

                foreach (Collider2D myCollider in myColliders)
                {
                    if (!myCollider.isTrigger)
                    {
                        foreach (Collider2D objCollider in objColliders)
                        {
                            Physics2D.IgnoreCollision(myCollider, objCollider); 
                        }
                    }
                }
            }
        }
    }
}
