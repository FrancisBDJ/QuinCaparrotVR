using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPickUpController : MonoBehaviour
{
    [SerializeField] private Transform holdArea;

    public GameObject heldObj;

    private Rigidbody heldObjRb;

    [SerializeField] private float pickupRange = 5.0f;

    [SerializeField] private float pickupForce = 25.0f;

    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                LayerMask mask = LayerMask.GetMask("Selectable");
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                        pickupRange, mask))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            } 
            else
            {
                DropObject();
            }
        }
        
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRb = pickObj.GetComponent<Rigidbody>();
            heldObjRb.useGravity = false;
            heldObjRb.drag = 10;
            pickObj.transform.LookAt(_player.transform);
            pickObj.transform.Rotate(0,180,-90);
            heldObjRb.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRb.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }
    
    
    void DropObject()
    {
        heldObjRb.useGravity = true;
        heldObjRb.drag = 1;
        heldObjRb.constraints = RigidbodyConstraints.None;

        heldObjRb.transform.parent = null;
        heldObj = null;
    }
    
    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.05f)
        {
            Vector3 moveDirection = holdArea.position - heldObj.transform.position;
            heldObjRb.AddForce(moveDirection * pickupForce);
        }
    }
}
