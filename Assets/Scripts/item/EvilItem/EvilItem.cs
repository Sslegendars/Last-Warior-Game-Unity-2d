using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilItem : Item
{
    protected internal Animator _animator;
    protected internal float destroyDelay;
    protected void Awake()
    {
        
        _animator = GetComponent<Animator>();
    }
    
    
}
