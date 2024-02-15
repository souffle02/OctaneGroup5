using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float rotationSpeed = 30.0f;
    private float movementSpeed = 10.0f;
    private float handbrakeDrag = 10f; // Increased drag for handbrake effect
    private float normalDrag = 0.1f; // Normal driving drag
    private float handbrakeAngularDrag = 10f; // Angular drag for sliding
    private float normalAngularDrag = 1f; // Normal angular drag

    private Rigidbody rb;
    private PlayerInput inputActions;
    private Vector2 moveInput;
    private float rotateInput;
    private bool handbrakeActive = false; // Handbrake flag
    private Vector3 lastDirectionBeforeHandbrake;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody component missing from this GameObject");

        inputActions = new PlayerInput();

        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Player.Rotate.performed += ctx => rotateInput = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += ctx => rotateInput = 0;

        // Listen for the "Drift" action
        inputActions.Player.Drift.performed += ctx => ToggleHandbrake(true);
        inputActions.Player.Drift.canceled += ctx => ToggleHandbrake(false);
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
        if (!handbrakeActive)
        {
            HandleMovement();
            HandleRotation();
        }
        else
        {
            HandleHandbrake();
        }
    }

private void HandleMovement()
    {
        Vector3 moveDirection = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * new Vector3(moveInput.x, 0, 40);
        Vector3 movement = moveDirection.normalized * movementSpeed;
        lastDirectionBeforeHandbrake = transform.forward;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void HandleRotation()
    {
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotateInput * rotationSpeed * Time.fixedDeltaTime, 0));
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

private void HandleHandbrake()
{
    if (Mathf.Abs(rotateInput) > 0)
    {
        float rotationAmount = rotateInput * (rotationSpeed * 3 /2) * Time.fixedDeltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotationAmount, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }

    // Calculate the current direction based on input
    Quaternion currentRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    Vector3 newDirectionInput = new Vector3(moveInput.x, 0, 37);
    Vector3 currentDirection = (currentRotation * newDirectionInput).normalized;

    // Blend the last direction before handbrake and the current direction
    Vector3 blendedDirection = Vector3.Lerp(lastDirectionBeforeHandbrake.normalized, currentDirection, 0.5f);

    // Apply movement speed
    Vector3 movement = blendedDirection * movementSpeed;

    // Move the rigidbody
    rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
}


    private void ToggleHandbrake(bool active)
    {
        handbrakeActive = active;
        rb.drag = active ? handbrakeDrag : normalDrag;
        rb.angularDrag = active ? handbrakeAngularDrag : normalAngularDrag;

        if (!active)
        {
            // Adjust the car's velocity direction when handbrake is released
            rb.velocity = transform.forward * rb.velocity.magnitude;
        }
    }
}
