using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private GameObject gravePrefab;
    private GameObject _player;
    
   

    private void OnEnable()
    {
        _player = GameObject.Find("Player");
       
        if (_player != null)
        {
            transform.position = _player.transform.position + Vector3.up / 2;
        }
        else
        {
            Debug.LogError("Player object not found.");
        }

        StartCoroutine(SpawnGraveCoroutine());
    }

    private IEnumerator SpawnGraveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
            
            Instantiate(gravePrefab, transform.position, Quaternion.identity);
        }
    }



}
