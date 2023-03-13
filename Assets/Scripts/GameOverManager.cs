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
    [SerializeField] private TextMeshProUGUI txtWin;
    public BooleanSO winSO;
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
            if (File.Exists(filePath))
            {
                var playersInfo = JsonConvert.DeserializeObject<AllPlayersInfoClass>(File.ReadAllText(filePath));
                playersInfo.PlayersInfos = playersInfo.PlayersInfos.ToList();
                PlayerInfoClass lastPlayer = playersInfo.PlayersInfos[playersInfo.PlayersInfos.Count - 1];
                txtWin.text = "Congratulations!" + lastPlayer.Name + "Win with " + lastPlayer.Points + " points";
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
