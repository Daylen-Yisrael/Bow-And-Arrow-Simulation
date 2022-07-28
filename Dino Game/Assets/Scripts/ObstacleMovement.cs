using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 8;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        speed += Time.deltaTime / 2;        
    }
}
