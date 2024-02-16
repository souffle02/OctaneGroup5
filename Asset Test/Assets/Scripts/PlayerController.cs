using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float rotationSpeed = 40.0f;
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
    //boosting variables
    private bool isBoosting = false;
    private float boostAmount = 30f;
    private float boostDuration = 2f; // Duration of the boost effect
    private float boostCooldown = 5f; // Time before another boost can be activated
    private float boostTimer = 0f; // Tracks the duration of the current boost
    private float driftTime = 0f; // Tracks how long the player has been drifting
    private float maxBoost = 100f; // Maximum boost that can be accumulated


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
            driftTime += Time.fixedDeltaTime; // Accumulate drift time

            HandleHandbrake();
        }
        // Handle boost if active
        if (isBoosting)
        {
            ApplyBoost();
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
        Vector3 newDirectionInput = new Vector3(moveInput.x, 0, 10);
        Vector3 currentDirection = (currentRotation * newDirectionInput).normalized;

        // Blend the last direction before handbrake and the current direction
        Vector3 blendedDirection = Vector3.Lerp(lastDirectionBeforeHandbrake.normalized, currentDirection, 0.4f);

        // Apply movement speed
        Vector3 movement = blendedDirection * movementSpeed;

        // Move the rigidbody
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }


    private void ToggleHandbrake(bool active)
{
    handbrakeActive = active;
    if (active)
    {
        // Reset drift time when handbrake is activated
        driftTime = 0f;
    }
    else
    {
        // Calculate boost amount based on drift time when handbrake is released
        boostAmount += driftTime; // Adjust this calculation as needed
        boostAmount = Mathf.Min(boostAmount, maxBoost); // Cap the boost amount

        // Reset drift time
        driftTime = 0f;

        // Start boosting if there's accumulated boost
        if (boostAmount > 0)
        {
            isBoosting = true;
            boostTimer = 0f; // Reset the boost timer
        }

        // Adjust the car's velocity direction when handbrake is released
        rb.velocity = transform.forward * rb.velocity.magnitude;
    }

    // Update Rigidbody drag values
    rb.drag = active ? handbrakeDrag : normalDrag;
    rb.angularDrag = active ? handbrakeAngularDrag : normalAngularDrag;
}
    private void ApplyBoost()
    {
        if (boostAmount > 0 && boostTimer < boostDuration)
        {
            // Apply force in the forward direction
            rb.AddForce(transform.forward * boostAmount, ForceMode.Impulse);

            // Update boost timer
            boostTimer += Time.fixedDeltaTime;
        }
        else
        {
            // Reset boost state when duration is over or boost is depleted
            isBoosting = false;
            boostTimer = 0f;
            boostAmount = 0f; // Optionally reset boost amount here or on specific conditions
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameManager.Instance.GameOver();
        }
    }
}