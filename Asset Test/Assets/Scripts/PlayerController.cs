using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 100.0f;
    public float movementSpeed = 5.0f;
    
    public GameObject projectilePrefab;
    private PlayerInput inputActions;
    private Vector2 moveInput;
    private float rotateInput; // Changed to a float to represent left/right rotation
    [SerializeField] public GameObject particleEffectPrefab; // Reference to the Particle System Prefab
    [SerializeField] public AudioSource firesfx;

    private void Awake()
    {
        inputActions = new PlayerInput();

        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        // Updated to read from a float value based on A and D key inputs
        inputActions.Player.Rotate.performed += ctx => rotateInput = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += ctx => rotateInput = 0;

    }

    public void OnEnable()
    {
        inputActions.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnDisable()
    {
        inputActions.Player.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * new Vector3(moveInput.x, 0, 4);
        Vector3 movement = moveDirection.normalized * movementSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void HandleRotation()
    {
        // Rotation is now based on the rotateInput value from A and D keys
        Vector3 rotation = new Vector3(0, rotateInput, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.World);
    }

    
}
