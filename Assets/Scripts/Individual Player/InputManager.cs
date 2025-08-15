using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;

    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("InputManager");
                    instance = obj.AddComponent<InputManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        playerControls = new PlayerControls();
        
    }

    void OnEnable()
    {
        playerControls.Enable();
        
    }

    void OnDisable()
    {
        playerControls.Disable();
       
    }


    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Moving.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool IsJumping()
    {
        return playerControls.Player.Jump.triggered;
    }

    public bool IsInteract()
    {
        return playerControls.Player.Interact.triggered;
        
    }

    public bool isUse()
    {
        return playerControls.Player.LClick.triggered;
        
            
        
    }

    public bool isDropping()
    {
        return playerControls.Player.Drop.triggered;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
