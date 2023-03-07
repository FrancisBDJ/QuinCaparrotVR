using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _startGameBtn;
    [SerializeField] private Button _optionsBtn;
    [SerializeField] private Button _quitBtn;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _startGameBtn.onClick.AddListener(StartGame);
        _optionsBtn.onClick.AddListener(Options);
        _quitBtn.onClick.AddListener(Quit);
        Debug.Log("Main menu manager initialized");
    }
    
    private void StartGame()
        {
            SceneManager.LoadScene("Level1");
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

    private void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
