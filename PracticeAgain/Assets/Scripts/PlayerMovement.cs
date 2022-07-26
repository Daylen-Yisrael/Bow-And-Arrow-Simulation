using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] [Range(0, 10000)] int _forwardSpeed = 2000;
    [SerializeField] int _moveSpeed = 1500;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rb.AddForce(0, 0, _forwardSpeed  * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(-_moveSpeed  * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(_moveSpeed  * Time.deltaTime, 0, 0);
        }
    }
}
