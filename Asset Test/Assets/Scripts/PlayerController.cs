using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float lives = 3; // Starting lives for player

    public WheelCollider frontDriverW, frontPassengerW, rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT, rearDriverT, rearPassengerT;
    private float m_steeringAngle;
    public float maxSteerAngle = 10;
    public float motorForce = 2000;
    public float brakeForce = 100;
    private float handbrakeForce = 100f; // Use this for handbrake effect
    private float steeringSensitivity = 2f; // Adjust this value to find the right responsiveness.

    private float currentSteerAngle = 0f;


    private Rigidbody rb;
    private PlayerInput inputActions;
    private Vector2 moveInput;
    private float rotateInput;
    private bool handbrakeActive = false; // Handbrake flag
    private float m_rotateInput; // Add this to capture the rotate input

    


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody component missing from this GameObject");

        inputActions = new PlayerInput();

        

        // Listen for the "Drift" action
        inputActions.Player.Drift.performed += ctx => ToggleHandbrake(true);
        inputActions.Player.Drift.canceled += ctx => ToggleHandbrake(false);
     // Setup rotate action listener
        inputActions.Player.Rotate.performed += ctx => m_rotateInput = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += ctx => m_rotateInput = 0;
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
        inputActions.Player.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void FixedUpdate()
    {
        Steer();
        Accelerate();
        UpdateWheelPoses();

        if (handbrakeActive)
        {
            ApplyHandbrake();
            Debug.Log("Handbrake");
        }
        else
        {
            frontDriverW.brakeTorque = 0;
            frontPassengerW.brakeTorque = 0;
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
    }

    private void Steer()
    {
            // Calculate the target steering angle based on input and the maximum steering angle.
        float targetSteeringAngle = maxSteerAngle * m_rotateInput;

        if (Mathf.Abs(m_rotateInput) < 0.01f)
        {
            // If there's no input, smoothly return the wheels to the center position (0 degrees).
            currentSteerAngle = Mathf.Lerp(currentSteerAngle, 0, steeringSensitivity * 10 * Time.deltaTime);
        }
        else
        {
            // If there is input, smoothly transition towards the target steering angle.
            currentSteerAngle = Mathf.Lerp(currentSteerAngle, targetSteeringAngle, steeringSensitivity * Time.deltaTime);
        }

        // Apply the interpolated steering angle to the wheel colliders.
        frontDriverW.steerAngle = currentSteerAngle;
        frontPassengerW.steerAngle = currentSteerAngle;
    }
    private void Accelerate()
    {
        
        rearDriverW.motorTorque =  motorForce;
        rearPassengerW.motorTorque =  motorForce;

    }

    private void ApplyHandbrake()
    {
        var brakeTorque = handbrakeForce;
        rearDriverW.brakeTorque = brakeTorque;
        rearPassengerW.brakeTorque = brakeTorque;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 _pos;
        Quaternion _quat;

        collider.GetWorldPose(out _pos, out _quat);

        transform.position = _pos;
        transform.rotation = _quat;
    }

    private void ToggleHandbrake(bool active)
    {
        handbrakeActive = active;
        handbrakeForce = active ? brakeForce : 0f;
    }
}
