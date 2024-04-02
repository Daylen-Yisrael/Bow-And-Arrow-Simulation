using System;
using UnityEngine;

namespace _Project.BowTest.Scripts
{
    public class BowController : MonoBehaviour
    {
        Transform _playerCam;
        Transform _player;
        void Awake()
        {
            _playerCam = FindObjectOfType<BowTestCamera>().transform;
            _player = FindObjectOfType<BowTesterMovement>().transform;
        }

        void Start()
        {
            transform.SetParent(_playerCam);
        }

        private void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }

    }
}
