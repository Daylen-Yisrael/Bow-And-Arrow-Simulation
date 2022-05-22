using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpVelocity = 2;
    Rigidbody _rb;
    bool _isJumping;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
    }

    void FixedUpdate()
    {
        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            _isJumping = false;
        }
    }
}    
