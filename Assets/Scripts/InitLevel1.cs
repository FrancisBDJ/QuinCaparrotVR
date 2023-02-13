using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLevel1 : MonoBehaviour
{
    private GameManager _gameManager;

    private Timer _timer;
    // Start is called before the first frame update
    void Start()
    {
        _timer = FindObjectOfType<Timer>();
        _gameManager = FindObjectOfType<GameManager>();
        _timer.ResetTimer();
        _gameManager.InitLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}