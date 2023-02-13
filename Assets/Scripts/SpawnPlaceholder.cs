using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlaceholder : MonoBehaviour
{
    [SerializeField] private List<string> nomsPedestals = new List<string>();

    // Cada Prefab pedestal contiene un GameObject hijo llamado TxtNomCaparrot
    public List<GameObject> prefabsPedestal;
    private PlaceHolderChecker _placeHolderChecker;

    private void Awake()
    {
        _placeHolderChecker = FindObjectOfType<PlaceHolderChecker>();
        _placeHolderChecker.placeHolders = prefabsPedestal;
    }

    // Start is called before the first frame update
    void Start()
    {
        nomsPedestals = nomsPedestals.OrderBy(x => Random.value).ToList();
        
        for (int i = 0; i < prefabsPedestal.Count; i++)
        {
            prefabsPedestal[i].GetComponent<ObjectPlaced>().num = i;
            
            GameObject textObject = new GameObject("txtPedestal");
            Transform placa = prefabsPedestal[i].transform.Find("Canvas").Find("Placa");
            textObject.transform.SetParent(placa);

            
            TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
            textComponent.text = nomsPedestals[i];
            
           
            RectTransform rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1f, 1f);
            rectTransform.localPosition = new Vector3(-0.038f, -0.02f, 0f);
            textComponent.alignment = TextAlignmentOptions.Center;
            rectTransform.rotation = Quaternion.Euler(0f, -90f, 0f);
            textComponent.fontSize = 0.15f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
