using UnityEngine;

public class InteractableScript : MonoBehaviour
{

    
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void InteractableTrigger()
    {
        //GM.PlayerInteractEvent(int event, this.gameobject)
    }
}
