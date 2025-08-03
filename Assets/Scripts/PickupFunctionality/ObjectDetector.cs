using UnityEditor;
using UnityEngine;



public class ObjectDetector : MonoBehaviour
{

    public Camera camera;

    public float rayDistance;

    Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    void Awake()
    {
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = camera.ScreenPointToRay(position);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent<PickUpAbleObject>(out PickUpAbleObject obj))
            {
                
            }
        }

    }
    

}
