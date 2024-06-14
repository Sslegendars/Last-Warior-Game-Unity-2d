
public class CollectItem : Item
{
    private CollectItemMovement collectItemMovement;

    protected override void Start()
    {
        base.Start();
        

        if (collectItemMovement._rigidbody != null && gameObject != null)
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
    protected override void InitializeComponents()
    {
        base.InitializeComponents();
        collectItemMovement = GetComponent<CollectItemMovement>();
    }
}