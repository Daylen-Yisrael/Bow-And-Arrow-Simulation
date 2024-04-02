using System;
using UnityEngine;

namespace _Project.BowTest.Scripts
{
    public class ArrowTest : MonoBehaviour, IArrow
    {
        Rigidbody _rb;
        Collider _col;
        bool _canFire;
        float _arrowForce;
    
        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _col = GetComponent<Collider>();
        }

        void Start()
        {
            _rb.useGravity = false;
            _col.isTrigger = true;
        }


        void FixedUpdate()
        {
            if (_canFire)
            {
                _rb.useGravity = true;
                _col.isTrigger = false;
                _rb.AddForce(transform.up * _arrowForce, ForceMode.VelocityChange);
                _canFire = false;
            }
        }

        public void Fire(float force)
        {
            _arrowForce = force;
            transform.SetParent(null);
            _canFire = true;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Bow"))
            {
                //Debug.Log(collision.gameObject.name, gameObject);
                _rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}
