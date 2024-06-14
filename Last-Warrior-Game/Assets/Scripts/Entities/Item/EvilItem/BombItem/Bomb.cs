using System.Collections;
using UnityEngine;

public class Bomb : EvilItem
{   
    [Header("Bomb Explosion Effect")]
    [SerializeField] 
    private GameObject explosionEffect;   
        
    private const float destroyTime = 0.4f;
    private const float soundStartDelay = 1f;
    private bool isExploding = false;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isExploding)
        {
            StartCoroutine(DestroyBombAndSpawnEffect());
            isExploding = true;
        }
    }

    private IEnumerator DestroyBombAndSpawnEffect()
    {
        destroyDelay = 2.6f;
        yield return new WaitForSeconds(soundStartDelay);

        AudioManager.Instance.Play(AudioManager.bombCountDownSoundName);       
        yield return new WaitForSeconds(destroyDelay);           

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioManager.Instance.Play(AudioManager.bombExplosionSoundName);
            
        }
        ItemDestroyed();
    }
    

    protected override void ItemDestroyed()
    {

        Destroy(gameObject, destroyTime);
    }  

}
