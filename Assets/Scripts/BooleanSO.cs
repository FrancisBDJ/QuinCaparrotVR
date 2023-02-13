using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BooleanData", menuName = "ScriptableObjects/BooleanScriptableObject", order = 1)]
public class BooleanSO : ScriptableObject
{
    private bool _value = false;

    public bool Value
    {
        get => _value;
        set => _value = value;
    }
}
