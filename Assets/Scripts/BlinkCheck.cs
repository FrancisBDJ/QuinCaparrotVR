using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkCheck : MonoBehaviour
{

    private PlaceHolderChecker _placeHolderChecker;
    private RaycastPickUpController _raycastPickUpController;
    private bool blinkEnable = true;
    private bool loop = false;
    public bool buttonHit = false;

    private void Start()
    {
        _placeHolderChecker = FindObjectOfType<PlaceHolderChecker>();
        _raycastPickUpController = FindObjectOfType<RaycastPickUpController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_placeHolderChecker.caparrotsInPedestals[0] && _placeHolderChecker.caparrotsInPedestals[1] &&
            _placeHolderChecker.caparrotsInPedestals[2] && blinkEnable && _raycastPickUpController.heldObj == null)
        {
            blinkEnable = false;
            loop = true;
            StartCoroutine(ButtonBlink());
        }

        if (_placeHolderChecker.caparrotsInPedestals[0] == false ||
            _placeHolderChecker.caparrotsInPedestals[1] == false ||
            _placeHolderChecker.caparrotsInPedestals[2] == false)
        {
            blinkEnable = true;
            buttonHit = false;
        }

        IEnumerator ButtonBlink()
        {
            while (loop && buttonHit == false)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                yield return new WaitForSeconds(0.3f);
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                yield return new WaitForSeconds(0.3f);

                if (_placeHolderChecker.caparrotsInPedestals[0] == false ||
                    _placeHolderChecker.caparrotsInPedestals[1] == false ||
                    _placeHolderChecker.caparrotsInPedestals[2] == false)
                {
                    loop = false;
                }
            }
        }
    }
}
