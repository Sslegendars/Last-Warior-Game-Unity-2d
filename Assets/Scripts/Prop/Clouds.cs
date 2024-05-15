using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float boundX = 21f;    
    
    void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if(transform.position.x <= -boundX)
        {
            Destroy(gameObject);
        }
    }
}
