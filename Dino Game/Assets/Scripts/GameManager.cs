using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    Jump _jumpScript;
    [SerializeField] GameObject _spawner;
    ObstacleSpawner _spawnerScript;
    [SerializeField] Text _score;
    
    [SerializeField] Text _gameOverText;
    [SerializeField] Text _gameStartText;
    // Start is called before the first frame update

    void Awake()
    {
        _jumpScript = _player.GetComponent<Jump>();
        _spawnerScript = _spawner.GetComponent<ObstacleSpawner>();
    }

    void Start()
    {
        _gameOverText.enabled = false;
        _spawnerScript.enabled = false;
        _score.enabled = false;
        _jumpScript.enabled = false;
        _gameStartText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Game Start
        if (Input.GetKeyDown(KeyCode.Space) && _gameStartText.enabled)
        {
            _gameStartText.enabled = false;
            _score.enabled = true;
            _jumpScript.enabled = true;
            _spawnerScript.enabled = true;
        }

        _score.text = _spawnerScript.obstacleCount.ToString();
        
        if (_jumpScript._gameOver)
        {
            Time.timeScale = 0;
            _gameOverText.enabled = true;
            _jumpScript.enabled = false;
            _spawnerScript.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _jumpScript._gameOver)
        {
            Time.timeScale = 2;
            SceneManager.LoadScene(0);
        }
        
        
    }
}
