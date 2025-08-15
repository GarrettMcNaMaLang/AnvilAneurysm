
using JetBrains.Annotations;
using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerScript : MonoBehaviour
{
    

    //camera Parameters
    public float cNormalFOV;

    public float cSprintFOV;

    public float cSmoothingFOV;


    //speed variable
    public float maxSpeed => sprintInput ? sprintSpeed : walkSpeed;

    public float walkSpeed;

    public float sprintSpeed;
    public float acceleration;

    //public float gravValue;

    //Physics Values

    public float vVelocity;
    public float gravScale;

    public float jumpHeight;
    public bool IsGrounded => cController.isGrounded;

    public Vector3 currVelocity { get; private set; }

    public float currSpeed { get; private set; }

    public bool Sprinting
    {
        get
        {
            return sprintInput && currSpeed > 0.1f;
        }
    }



    //input Vectors
    public Vector2 mInput;
    public Vector2 lInput;

    public bool sprintInput;

    //Looking Parameters
    public Vector2 lookSensitivity = new Vector2(0.1f, 0.1f);

    public float pitchLimit;

    [SerializeField] float currPitch = 0f;

    public float CurrPitch
    {
        get => currPitch;

        set
        {
            currPitch = Mathf.Clamp(value, -pitchLimit, pitchLimit);
        }
    }

    [SerializeField] CinemachineCamera cCamera;
    [SerializeField] CharacterController cController;

    void OnValidate()
    {
        if (cController == null)
        {
            cController = GetComponent<CharacterController>();
        }
    }

    

    void Update()
    {
        MoveUpdate();
        LookUpdate();
        CameraUpdate();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void MoveUpdate()
    {
        Vector3 movement = transform.forward * mInput.y + transform.right * mInput.x;

        movement.y = 0f;
        movement.Normalize();

        if (movement.sqrMagnitude >= 0.01f)
        {
            currVelocity = Vector3.MoveTowards(currVelocity, movement * maxSpeed, acceleration * Time.deltaTime);


        }
        else
        {
            currVelocity = Vector3.MoveTowards(currVelocity, Vector3.zero, acceleration * Time.deltaTime);
        }


        if (IsGrounded && vVelocity <= 0.01f)
        {
            vVelocity = -3f;

        }
        else
        {
            vVelocity += Physics.gravity.y * gravScale * Time.deltaTime;

        }




        Vector3 fullVelocity = new Vector3(currVelocity.x, vVelocity, currVelocity.z);



        cController.Move(fullVelocity * Time.deltaTime);
    }

    public void TryJump()
    {
        if (IsGrounded == false)
        {
            return;
        }

        vVelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y * gravScale);
    }

    public void LeftClickEvent()
    {

    }

    void LookUpdate()
    {
        Vector2 input = new Vector2(lInput.x * lookSensitivity.x, lInput.y * lookSensitivity.y);

        //looking up and down
        CurrPitch -= input.y;

        cCamera.transform.localRotation = Quaternion.Euler(currPitch, 0f, 0f);

        //looking left and right

        transform.Rotate(Vector3.up * input.x);
    }

    void CameraUpdate()
    {
        float targetFOV = cNormalFOV;

        if (Sprinting)
        {
            float speedRatio = currSpeed / sprintSpeed;

            targetFOV = Mathf.Lerp(cNormalFOV, cSprintFOV, speedRatio);
        }
        cCamera.Lens.FieldOfView = Mathf.Lerp(cCamera.Lens.FieldOfView, targetFOV, cSmoothingFOV * Time.deltaTime);
    }

    void OnLook(InputValue val)
    {
        lInput = val.Get<Vector2>();
    }

    void OnMoving(InputValue val)
    {
        mInput = val.Get<Vector2>();
    }

    void OnSprint(InputValue val)
    {
        sprintInput = val.isPressed;
    }

    void OnJump(InputValue val)
    {
        if (val.isPressed)
        {
            TryJump();
        }
    }

    bool LCEvent;

    void OnClick(InputValue val)
    {

        if (val.isPressed && LCEvent)
        {



        }
    }



   
    
}
