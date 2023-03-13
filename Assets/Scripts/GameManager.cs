using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public bool win;
    public BooleanSO winSO;
    private GameObject _player;
    private Timer _timer;
    public int points = 10000;
    [SerializeField] private Canvas scoreCanvas;
    [SerializeField] private Button btnConfirm;
    [SerializeField] private TextMeshProUGUI txtPoints;
    

    // Start is called before the first frame update
    void Start()
    {
        InitLevel();
        btnConfirm.onClick.AddListener(Confirm);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void Confirm()
    {
        
        var filePath = Path.Combine(Application.persistentDataPath, "Leaderboard.json");
        AllPlayersInfoClass playersInfo = new AllPlayersInfoClass();
        playersInfo.PlayersInfos = new List<PlayerInfoClass>();
        
        if (File.Exists(filePath))
        { 
            playersInfo = JsonConvert.DeserializeObject<AllPlayersInfoClass>(File.ReadAllText(filePath)); 
        }
        
        
        PlayerInfoClass player = new PlayerInfoClass();
        player.Name = "You";
        player.Points = points;

        
        playersInfo.PlayersInfos.Add(player);
        var jsonString = JsonConvert.SerializeObject(playersInfo);
        File.WriteAllText(filePath, jsonString);


        SceneManager.LoadScene("Game Over");
    }
    
    public void EndGame()
    {
        _timer.StopTimer();
        if (winSO.Value)
        {
            txtPoints.text = "Congratulations! You Win with " + points + " points";
            scoreCanvas.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void InitLevel()
    {
        _timer = FindObjectOfType<Timer>();
       
    }
}
