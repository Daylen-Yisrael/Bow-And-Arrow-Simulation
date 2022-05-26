using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _jumpVelocity;
    [SerializeField] float _moveSpeed;
    float _horizontalInput;
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

        _horizontalInput = Input.GetAxis("Horizontal") * _moveSpeed;
        
        

    }

    void FixedUpdate()
    {
        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * _jumpVelocity, ForceMode.Impulse);
            _isJumping = false;
        }

        _rb.velocity = new Vector3(_horizontalInput, _rb.velocity.y, 0);
    }
}    
