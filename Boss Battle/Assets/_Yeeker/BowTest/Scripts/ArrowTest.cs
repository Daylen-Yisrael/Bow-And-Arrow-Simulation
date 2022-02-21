using System;
using System.Collections;
using System.Collections.Generic;
using _Yeeker.BowTest.Scripts;
using UnityEngine;

public class ArrowTest : MonoBehaviour, IArrow
{
    Rigidbody _rb;
    Collider _col;
    bool _canFire;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
    }

    void Start()
    {
        _rb.isKinematic = true;
        _col.isTrigger = true;
    }


    void FixedUpdate()
    {
        if (_canFire)
        {
            _rb.AddForce(Vector3.up * 50, ForceMode.Impulse);
            _canFire = false;
        }
    }

    public void Fire()
    {
        _rb.isKinematic = false;
        _col.isTrigger = false;
        bool _canFire = true;
    }
}
