using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    private int timerInitialValue = 180;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField] 
    private TextMeshProUGUI _timerText;
    private float _timeRemaining;
    [SerializeField] 
    private Slider _timerSlider;

 
    void DisplayTime(float _timeToDisplay)
    {
        _timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(_timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(_timeToDisplay % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Countdown()
    {
        if (_timeRemaining >= 0)
        { 
            _timeRemaining -= Time.deltaTime;
        }
        else
        { 
            _gameManager.win.Value = false; 
            _gameManager.EndGame();
        }

        DisplayTime(_timeRemaining);
        _timerSlider.value = _timeRemaining;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    public void ResetTimer()
    {
        _timerSlider.gameObject.SetActive(true);
        _timerText.gameObject.SetActive(true);
        _timeRemaining = timerInitialValue;
    }

    public void StopTimer()
    {
        _timerSlider.gameObject.SetActive(false);
        _timerText.gameObject.SetActive(false);
        
        if (_timeRemaining < 140)
        {
            //Debug.Log(40 * Math.Ceiling((100 - _timer)/10f));
            _gameManager.points -= (int) (40 * Math.Ceiling((140 - _timeRemaining)/10f));
            Debug.Log(_gameManager.points);
            if (_gameManager.points <= 0)
            {
                _gameManager.points = 0;
            }
        }
    }
}
