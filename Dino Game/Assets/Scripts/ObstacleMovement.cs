using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}