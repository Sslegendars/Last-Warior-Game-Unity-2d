using System.Collections;
using UnityEngine;

public class BosseEnemySpell : MonoBehaviour
{
    [SerializeField]
    private GameObject gravePrefab;
    [SerializeField]
    private int damageAmount = 10;
    private BossEnemyHealthSystem bossEnemyHealthSystem;
    private GameObject playerObject;
    private PlayerHealthSystem playerHealthSystem;

    void Start()
    {
        InitializeComponents();
    }
    private void OnEnable()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            SpellObjectPosition();
        }
        StartCoroutine(SpawnGraveCoroutine());
    }
    private void InitializeComponents()
    {

        FindBossEnemyParentObject();
        if (playerObject != null)
        {
            playerHealthSystem = playerObject.GetComponent<PlayerHealthSystem>();
        }

        playerHealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
    }
    private void SpellObjectPosition()
    {
        transform.position = playerObject.transform.position + Vector3.up / 2;
    }
    private void FindBossEnemyParentObject()
    {
        Transform parentTransform = transform.parent;
        while (parentTransform != null)
        {

            bossEnemyHealthSystem = parentTransform.GetComponent<BossEnemyHealthSystem>();
            if (bossEnemyHealthSystem != null)
            {
                break;
            }

            parentTransform = parentTransform.parent;
        }
    }
    private IEnumerator SpawnGraveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(gravePrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealthSystem != null && bossEnemyHealthSystem != null)
            {
                playerHealthSystem.TakeDamage(damageAmount);
                bossEnemyHealthSystem.StealHealth(damageAmount);
            }
        }
    }
}
