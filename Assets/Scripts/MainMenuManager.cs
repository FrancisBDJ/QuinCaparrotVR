using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _startGameBtn;

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        _startGameBtn.onClick.AddListener(StartGame);
        Debug.Log("Main menu manager initialized");
    }
}
