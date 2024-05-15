using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    [SerializeField] 
    private int damageAmount = 10;    
    //private EnemyHealth enemyHealth;
    private BossEnemyHealthSystem bossEnemyHealthSystem;
    private PlayerHealthSystem playerHealthSystem;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        bossEnemyHealthSystem = GameObject.Find("Boss_Enemy").GetComponent<BossEnemyHealthSystem>();
    } 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(playerHealthSystem != null && bossEnemyHealthSystem != null)
            {
                playerHealthSystem.TakeDamage(damageAmount);
                bossEnemyHealthSystem.StealHealth(damageAmount);
            }                         
                           
        }
    }  
  
}
