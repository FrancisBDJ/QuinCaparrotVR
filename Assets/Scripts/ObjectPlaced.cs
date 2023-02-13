using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectPlaced : MonoBehaviour
{
    private PlaceHolderChecker _placeHolderChecker;
    public int num;
    private string text;

    private GameObject objectPlaced;
    // Start is called before the first frame update
    void Start()
    {
        _placeHolderChecker = FindObjectOfType<PlaceHolderChecker>();
        StartCoroutine(LateStart());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
  
    /*private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == GameObject.Find(text + "(Clone)"))
        {
            _placeHolderChecker.objectPlaced[num] = true;
        }
        else
        {
            _placeHolderChecker.objectPlaced[num] = false;
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (objectPlaced == null)
        {
            objectPlaced = collision.gameObject;

            if (collision.gameObject == GameObject.Find(text + "(Clone)"))
            {
                _placeHolderChecker.objectPlaced[num] = true;
            }
            else
            {
                _placeHolderChecker.objectPlaced[num] = false;
            }

            _placeHolderChecker.caparrotsInPedestals[num] = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject == objectPlaced)
        {
            _placeHolderChecker.objectPlaced[num] = false;
            _placeHolderChecker.caparrotsInPedestals[num] = false;
            objectPlaced = null;
        }
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        text = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}