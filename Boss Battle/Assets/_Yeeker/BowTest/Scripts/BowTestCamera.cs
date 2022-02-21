using System;
using UnityEngine;

namespace _Yeeker.BowTest.Scripts
{
    public class BowTestCamera : MonoBehaviour
    {

        public float mouseSens = 10;

        Transform _bowTester;
        float xRotation = 0;
        float yRotation = 0;

        void Awake()
        {
            _bowTester = FindObjectOfType<BowTesterMovement>().transform;
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            transform.position = _bowTester.position + Vector3.up * 0.5f;
            
            float x = Input.GetAxisRaw("Mouse X") * mouseSens;
            float y = Input.GetAxisRaw("Mouse Y") * mouseSens;

            yRotation += x;
            xRotation -= y;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f );
            _bowTester.rotation = Quaternion.Euler(0f, yRotation,0f );

        }
    }
}
