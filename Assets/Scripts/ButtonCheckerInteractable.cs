using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonCheckerInteractable : XRBaseInteractable
{
    [Header("Input actions")]
    public InputAction action = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        action.Enable();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        action.Disable();
    }
    protected override void Awake()
    {
        base.Awake();
        action.started += PrimaryButtonPressed;
        action.canceled += PrimaryButtonReleased;
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        action.started -= PrimaryButtonPressed;
        action.canceled -= PrimaryButtonReleased;
    }

    private void PrimaryButtonReleased(InputAction.CallbackContext obj)
    {
        
    }

    private void PrimaryButtonPressed(InputAction.CallbackContext context)
    {
        if (base.isHovered)
        {
            GetComponent<PlaceHolderChecker>().CheckObjectsPlacedInPedestals();
        }
    }
}