using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

//

public class ObjectDetector : MonoBehaviour
{
    public static event Action LeftClickEvent;

    [SerializeField]
    private InputActionReference interactInput, dropInput, useInput;

    public LayerMask PickUpObjects;

    PlayerScript playerParent;
    public Camera camera;

    public GameObject holdHere, currObject;

    public float rayDistance = 5;

    public bool currInteracting;

    void Awake()
    {
        playerParent = GetComponentInParent<PlayerScript>();
    }


    void OnEnable()
    {
        
    }

    void OnDisable()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    RaycastHit hit;

    // Update is called once per frame
    void LateUpdate()
    {

        //Ray ray = camera.ScreenPointToRay(camera.transform.forward);
        //RaycastHit hit;
        Debug.DrawRay(camera.transform.position, camera.transform.forward * rayDistance, Color.red);

        if (hit.collider != null)
        {
            hit.collider.GetComponent<PickUpAbleObject>()?.BeingLookedAt(false);

        }

        if (currObject != null) //will return if the player is holding an object currently
            return;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, rayDistance, PickUpObjects))
            {
                //Highlight script]
                hit.collider.GetComponent<PickUpAbleObject>()?.BeingLookedAt(true);
            }

    }

    public void OnInteract(InputValue val)
    {
        Debug.Log("In Interact");
        
        if (hit.collider != null)
        {
            if (val.isPressed)
            {
                if (hit.collider.TryGetComponent<InteractableScript>(out InteractableScript Interactable))
                {
                    if (Interactable.PlayerAvailable)
                    {
                        Debug.Log("Interactable Object " + hit.collider.name);
                    //acquire hit object
                        Interactable.InteractableTrigger(playerParent);
                    }
                    
                    //currInteracting = true;
                }
                    
                if (hit.collider.TryGetComponent<HoldableObject>(out HoldableObject pickUp))
                {
                    currObject = hit.collider.gameObject;
                    currObject.transform.position = Vector3.zero;
                    currObject.transform.rotation = Quaternion.identity;

                    currObject.transform.SetParent(holdHere.transform, false);

                    if (hit.collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
                    {
                        rb.isKinematic = true;
                    }
                    return;
                }

                if (hit.collider.TryGetComponent<ValueObject>(out ValueObject value))
                {
                    Debug.Log("Value Object " + hit.collider.name);
                }
            }
        }
    }

    public void OnDrop(InputValue val)
    {
        if (currObject != null)
        {


            if (val.isPressed)
            {

                currObject.transform.SetParent(null);
                if (hit.collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.isKinematic = false;
                }
                currObject = null;
                return;
            }
            
        }
    }
    
    //OnUse in hand item
    public void OnLClick(InputAction.CallbackContext obj)
    {

    }
    

}
