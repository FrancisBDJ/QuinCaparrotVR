using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceHolderChecker : MonoBehaviour
{
    public List<bool> objectPlaced;
    public List<bool> caparrotsInPedestals;
    public List<GameObject> placeHolders;
    private GameManager _gameManager;
    private bool win = false;

    


    public void CheckObjectsPlacedInPedestals()
    {
        if (_gameManager.winSO.Value != true)
        {
            for (int i = 0; i < objectPlaced.Count; i++)
            {
                if (objectPlaced[i])
                {
                    placeHolders[i].GetComponent<MeshRenderer>().material.color = Color.green;
                }
                else
                {
                    placeHolders[i].GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }

            win = true;
            foreach (var objects in objectPlaced)
            {
                if (objects == false)
                {
                    win = false;
                    _gameManager.points -= 200;

                    if (_gameManager.points <= 0)
                    {
                        _gameManager.points = 0;
                    }
                }
            }

            if (win)
            {
                _gameManager.winSO.Value = true;
                _gameManager.EndGame();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        

        objectPlaced = Enumerable.Repeat(false, placeHolders.Count).ToList();
        caparrotsInPedestals = Enumerable.Repeat(false, placeHolders.Count).ToList();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
