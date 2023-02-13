using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelection : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private Material selectedObjectOriginalMaterial;
    [SerializeField] private float pickupRange = 5.0f;
    private RaycastPickUpController _pickUpController;
    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        _pickUpController = FindObjectOfType<RaycastPickUpController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            //selectionRenderer.material = defaultMaterial;
            selectionRenderer.material = selectedObjectOriginalMaterial;
            _selection = null;
        }
        
        RaycastHit hit;
        if (_pickUpController.heldObj == null)
        {
            LayerMask mask = LayerMask.GetMask("Selectable");
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, mask))
            {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectedObjectOriginalMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection; 
            }
        }
       
    }
}
