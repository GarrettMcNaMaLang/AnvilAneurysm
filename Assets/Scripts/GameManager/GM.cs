using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class GM : MonoBehaviour
{
    private static GM instance;

    public static GM Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;

        playerInstance = Object.FindAnyObjectByType<PlayerScript>();
    }

    public PlayerScript playerInstance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}