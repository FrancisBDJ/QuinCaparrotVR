using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnQuit;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    public BooleanSO winSO;
    [SerializeField] private GameObject[] leaderBoardPlayers;
    // Start is called before the first frame update
    void Start()
    {
        btnRestart.onClick.AddListener(Restart);
        btnMenu.onClick.AddListener(Menu);
        btnQuit.onClick.AddListener(Quit);
        

        if (winSO.Value)
        {
            losePanel.gameObject.SetActive(false);
            winPanel.gameObject.SetActive(true);
            var filePath = Path.Combine(Application.persistentDataPath, "Leaderboard.json");
            AllPlayersInfoClass playersInfo = JsonConvert.DeserializeObject<AllPlayersInfoClass>(File.ReadAllText(filePath));
            playersInfo.PlayersInfos = playersInfo.PlayersInfos.OrderByDescending(x => x.Points).ToList();
            for (int i = 0; i < leaderBoardPlayers.Length; i++)
            {
                if (i >= playersInfo.PlayersInfos.Count)
                {
                    break;
                }
                leaderBoardPlayers[i].transform.Find("txtUsername").GetComponent<TextMeshProUGUI>().text = playersInfo.PlayersInfos[i].Name;
                leaderBoardPlayers[i].transform.Find("txtPoints").GetComponent<TextMeshProUGUI>().text = playersInfo.PlayersInfos[i].Points.ToString();
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
    
    private void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Quit()
    {
#if UNITY_EDITOR
        if(EditorApplication.isPlaying) 
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#else
            Application.Quit();
#endif
    }
}
