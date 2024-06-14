using System.Collections;
using UnityEngine;

public class BosseEnemySpell : MonoBehaviour
{
    [SerializeField] private GameObject gravePrefab;
    [SerializeField] private int damageAmount = 10;
    private BossEnemyHealthSystem bossEnemyHealthSystem;

    private void Start()
    {
        InitializeComponents();
    }

    private void OnEnable()
    {
        if (PlayerController.Instance != null)
        {
            SpellObjectPosition();
        }
        StartCoroutine(SpawnGraveCoroutine());
    }

    private void InitializeComponents()
    {
        bossEnemyHealthSystem = GetComponentInParent<BossEnemyHealthSystem>();
       
    }

    private void SpellObjectPosition()
    {
        if (PlayerController.Instance != null)
        {
            transform.position = PlayerController.Instance.transform.position + Vector3.up * 0.5f;
        }
    }   

    private IEnumerator SpawnGraveCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(gravePrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.Instance != null && bossEnemyHealthSystem != null)
            {
                PlayerController.Instance.playerHealthSystem.TakeDamage(damageAmount);
                bossEnemyHealthSystem.StealHealth(damageAmount);
            }
        }
    }
}
