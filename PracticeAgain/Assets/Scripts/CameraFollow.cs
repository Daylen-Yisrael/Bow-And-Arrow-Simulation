using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform _playerTf;
    Vector3 _offset;
    
    void Awake()
    {
        _playerTf = FindObjectOfType<PlayerMovement>().transform;
        _offset = new Vector3(0, 3f, -5f);
    }

    void Update()
    {
        transform.position = _playerTf.position + _offset;
    }
}
