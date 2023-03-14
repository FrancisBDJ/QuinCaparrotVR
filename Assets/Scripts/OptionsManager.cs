using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    
    [SerializeField] public Button btnSaveExit;
    [SerializeField] public Toggle contiMove;
    public int ContMovent;

    void SaveExit()
    {
        if (contiMove.isOn)
        {
            ContMovent = 1;
            
        }
        else
        {
            ContMovent = 0;
        }
        
        if (!PlayerPrefs.HasKey("movement"))
        {
                
            PlayerPrefs.SetInt("movement", ContMovent);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("movement", ContMovent);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("Level1");
    }
    // Start is called before the first frame update
    void Start()
    {
        btnSaveExit.onClick.AddListener(SaveExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
