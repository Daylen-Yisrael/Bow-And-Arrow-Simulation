using TMPro.EditorUtilities;
using UnityEngine;

namespace _Yeeker.BowTest.Scripts
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
            _rb.isKinematic = true;
            _col.isTrigger = true;
            Debug.Log("Arrow Started");
        }


        void FixedUpdate()
        {
            if (_canFire)
            {
                _rb.isKinematic = false;
                _col.isTrigger = false;
                _rb.AddForce(transform.up * _arrowForce, ForceMode.Impulse);
                _canFire = false;
                Debug.Log("Arrow has been shot");

            }
        }

        public void Fire(float force)
        {
            _arrowForce = force;
            transform.SetParent(null);
            Debug.Log("Fire Button Started");
            _canFire = true;
        }
    }
}
