using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject cactusObstacle;
    public GameObject birdObstacle;
    float _timer = 0;
    float _maxTime = 3;
    bool birdOrCact;
    public int obstacleCount = 0;
    
    void Update()
    {
        if (_timer > _maxTime)
        {
            _timer = 0;
            RandomSpawn();
            if (birdOrCact)
            {
                GameObject newObs = Instantiate(birdObstacle);
                obstacleCount++;
                newObs.transform.position = transform.position + new Vector3(0, Random.Range(- 1, 1), 0);
                Destroy(newObs, 10f);
            }

            if (!birdOrCact)
            {
                GameObject newObs = Instantiate(cactusObstacle);
                obstacleCount++;
                newObs.transform.position = transform.position + new Vector3(0, -1.23f, 0);
                Destroy(newObs, 10f);
            }
        }
        _timer += Time.deltaTime;
    }

    void RandomSpawn()
    {
        if (Random.value > 0.5)
        {
            birdOrCact = true;
        }
        else
        {
            birdOrCact = false;
        }
    }
    
}
