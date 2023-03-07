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
    [SerializeField] public BooleanSO win;
    private GameObject _player;
    private Timer _timer;
    public int points = 10000;
    [SerializeField] private TextMeshProUGUI username;
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private Button btnConfirm;
    [SerializeField] private TextMeshProUGUI txtPoints;
    [SerializeField] private RawImage scoreBckgrnd;

    // Start is called before the first frame update
    void Start()
    {
        InitLevel();
        btnConfirm.onClick.AddListener(Confirm);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (userInput.text == String.Empty || userInput.text == null)
        {
            btnConfirm.interactable = false;
        }
        else
        {
            btnConfirm.interactable = true;
        }*/
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
        player.Name = userInput.text;
        player.Points = points;

        
        playersInfo.PlayersInfos.Add(player);
        var jsonString = JsonConvert.SerializeObject(playersInfo);
        File.WriteAllText(filePath, jsonString);


        SceneManager.LoadScene("Game Over");
    }
    
    public void EndGame()
    {
        _timer.StopTimer();
        if (win.Value)
        {
            txtPoints.text = "Points: " + points;
            scoreBckgrnd.gameObject.SetActive(true);
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
