using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InteractableScript : MonoBehaviour
{

    public SphereCollider triggerCol;

    public GameObject playerGoesHere;

    private bool playerAvailable;

    public bool PlayerAvailable
    {
        get
        {
            return playerAvailable;
        }

        set
        {
            playerAvailable = value;


        }
    }
    public enum interactEvents
    {
        Anvil,
        Kiln,
        Grind,

        Bed,

        Customer,

        Gladiator,
        Carve
    }

    public interactEvents chooseEvent;

    void Awake()
    {
        triggerCol = GetComponent<SphereCollider>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch(chooseEvent){
            case interactEvents.Anvil:
                {
                    Debug.Log("Anvil Event");
                    break;
                }
            case interactEvents.Kiln:
                {
                    Debug.Log("Kiln Event");
                    break;
                }
            case interactEvents.Grind:
                {
                    Debug.Log("Grind Event");
                    break;
                }
            case interactEvents.Bed:
                {
                    Debug.Log("Bed Event");
                    break;
                }
            case interactEvents.Customer:
                {
                    Debug.Log("Customer Event");
                    break;
                }
            case interactEvents.Gladiator:
                {
                    Debug.Log("Gladiator Event");
                    break;
                }
            case interactEvents.Carve:
                {
                    Debug.Log("Carve Event");
                    break;
                }
            default:
                {
                    Debug.Log("Error: Unrecognized Event");
                    break;
                }
        }
    }
    

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractableTrigger(PlayerScript player)
    {
        player.transform.position = playerGoesHere.transform.position;
        PlayerScript.inEvent = true;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerScript>(out PlayerScript player))
        {
            PlayerAvailable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerScript>(out PlayerScript player))
        {
            PlayerAvailable = false;
        }
    }
}
