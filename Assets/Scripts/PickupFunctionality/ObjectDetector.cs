using System;
using UnityEditor;
using UnityEngine;

//

public class ObjectDetector : MonoBehaviour
{
    public static event Action LeftClickEvent;

    public LayerMask PickUpObjects;

    PlayerScript playerParent;
    public Camera camera;

    public GameObject holdHere;

    public float rayDistance = 5;

    Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

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
        
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, rayDistance, PickUpObjects))
        {
            //Highlight script]
            hit.collider.GetComponent<PickUpAbleObject>()?.BeingLookedAt(true);
        }

    }
    

}
