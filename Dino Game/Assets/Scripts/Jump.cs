using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D _rb;
    bool _jumpPressed = false;
    public float jumpVelocity = 18;
    bool _isGrounded = true;
    public bool _gameOver = false;
    void Awake()
    {
        //_rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _jumpPressed = true;
            Debug.Log("Jump Activated");
        }
    }

    void FixedUpdate()
    {
        if (_jumpPressed)
        {
            _rb.velocity = Vector2.up * jumpVelocity;     
            _jumpPressed = false;
            Debug.Log("Jump Deactivated");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        _isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        _isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            _rb.gravityScale = 0;
            _rb.velocity = Vector2.zero;
            _gameOver = true;
        }
    }
}
