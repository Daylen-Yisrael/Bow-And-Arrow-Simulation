using System;
using UnityEngine;

namespace _Project.BowTest.Scripts
{
    public class BowTesterMovement : MonoBehaviour
    {
        public float _moveSpeed;

        Vector3 _velocity;
        Rigidbody _rb;
        
        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            MovementInput();
        }

        void FixedUpdate()
        {
            _rb.position += _velocity * Time.fixedDeltaTime;
        }

        void MovementInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            Vector3 input = transform.forward * z + transform.right * x;
            _velocity = input.normalized * _moveSpeed;
        }
    }
}
