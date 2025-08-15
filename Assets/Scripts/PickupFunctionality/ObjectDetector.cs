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

    public GameObject holdHere;

    public float rayDistance = 5;



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
        interactInput.action.performed += OnInteract;
        dropInput.action.performed += OnDrop;
        useInput.action.performed += OnLClick;
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

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, rayDistance, PickUpObjects))
        {
            //Highlight script]
            hit.collider.GetComponent<PickUpAbleObject>()?.BeingLookedAt(true);
        }

    }

    public void OnInteract(InputAction.CallbackContext obj)
    {
        Debug.Log("In Interact");
        
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
    }

    public void OnDrop(InputAction.CallbackContext obj)
    {

    }
    
    public void OnLClick(InputAction.CallbackContext obj)
    {

    }
    

}
