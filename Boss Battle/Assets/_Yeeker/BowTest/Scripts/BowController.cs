using System;
using UnityEngine;

namespace _Yeeker.BowTest.Scripts
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

        void Update()
        {
            transform.position = _player.position + Vector3.up * 0.5f;
            transform.eulerAngles = _playerCam.rotation.eulerAngles;
        }
    }
}
