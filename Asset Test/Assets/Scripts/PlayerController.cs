using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private TMP_Text progressText;
    public int coins = 0; // coins collected by the player
    public int lives = 3; // Starting lives for player
    private int currLevel = 1;

    // DRIVING
    public WheelCollider frontDriverW, frontPassengerW, rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT, rearDriverT, rearPassengerT;
    private float m_steeringAngle;
    public float maxSteerAngle = 20;
    public float motorForce = 2500;
    public float brakeForce = 100;
    private float handbrakeForce = 1500f; // Use this for handbrake effect
    private float steeringSensitivity = 1.8f; // Adjust this value to find the right responsiveness.

    private float currentSteerAngle = 0f;
    public WheelFrictionCurve originalRearWFriction;
    public WheelFrictionCurve driftRearWFriction;

    private Rigidbody rb;
    private PlayerInput inputActions;
    private Vector2 moveInput;
    private float rotateInput;
    private bool handbrakeActive = false; // Handbrake flag
    private float m_rotateInput; // Add this to capture the rotate input
    [SerializeField] GameObject Crasheffects;
    
    // CHECKPOINTS
    private int totalProgressCheckpoints; // Total number of progress checkpoints
    private int currentProgress; // Current progress count
    private int currentPercentage; // Current progress percentage

    // POWERUPS (lots of this prob gotta be refactored to respective scripts for the events
    public CountdownTimer countdownTimer;
    public GameObject rocketLauncherPrefab; // Rocket Launcher
    private bool canShoot = false; // If has rocket launcher powerup

    private bool isInvincible = false; // If has invincible powerup
    // private bool coinsDoubled = false; // If has coin multiplier
    private bool timewarpActive = false; // If has timewarp powerup

    // EVENTS
    public static event Action<PlayerController> onPlayerLoseLifeEvent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody component missing from this GameObject");

        inputActions = new PlayerInput();

        

        // Listen for the "Drift" action
        inputActions.Player.Drift.performed += ctx => ToggleHandbrake(true);
        inputActions.Player.Drift.canceled += ctx => ToggleHandbrake(false);

        // Used for progress counter
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Progress");
        totalProgressCheckpoints = checkpoints.Length;
        Debug.Log(totalProgressCheckpoints);

        inputActions.Player.Shoot.performed += ctx => TryShoot();
     // Setup rotate action listener
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        inputActions.Player.Rotate.performed += ctx => m_rotateInput = ctx.ReadValue<float>();
        inputActions.Player.Rotate.canceled += ctx => m_rotateInput = 0;


        // Setup original friction curves
        originalRearWFriction = rearDriverW.sidewaysFriction;
        
        // Setup drift friction curves
        driftRearWFriction = originalRearWFriction;
        driftRearWFriction.stiffness = 0.5f; // Adjust this value for desired drift behavior, lower values = more drift

        // Other initialization...

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
        
        float force = motorForce * moveInput.y;
        rearDriverW.motorTorque = force;
        rearPassengerW.motorTorque = force;
    

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
    
    if (active)
    {
        // Apply drift friction curves
        ApplyDriftFriction();
    }
    else
    {
        // Revert to original friction curves
        RevertOriginalFriction();
    }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.CompareTag("Finish"))
        {
            if(currLevel == 1)
            {
                GameManager.Instance.Level1End();
            }
            else if(currLevel == 2)
            {
                GameManager.Instance.Level2End();
            }
            else if(currLevel == 3)
            {
                GameManager.Instance.Level3End();
            }
            // GameManager.Instance.LevelEnd();
        }
        if (other.CompareTag("Progress"))
        {
            // Debug.Log("Calculating stuff");
            currentProgress++;
            CalculatePercentage();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            if(!isInvincible)LoseLife();
            Destroy(collision.gameObject);
        }
    }

    private void LoseLife() //needs to have an update for add life, disconnect from livescounterscript.fs
    {
        // lives -= 1; // Subtract one life
        Debug.Log("Life lost!");
        onPlayerLoseLifeEvent?.Invoke(this);
        // LivesCounterScript.LivesInstance.UpdateLives();
        Crasheffects.gameObject.SetActive(true);
        /*
        if (lives <= 0) // DONT HANDLE GAMEOVER LOGIC IN THIS SCRIPT. this is still here in case we need to revert any changes
        {
            Debug.Log("Game Over!");
            // Handle game over logic here
        }
        */
    }

    public void AddLife()
    { // DONT HANDLE ADDLIFE LOGIC IN THIS SCRIPT. this is still here in case we need to revert any changes
        lives += 1;
        Debug.Log("Life gained! Remaining lives: " + lives);
        // LivesCounterScript.LivesInstance.UpdateLives();
    }

    /* public void AddCoin()
    { // DONT HANDLE ADDCOIN LOGIC IN THIS SCRIPT. this is still here in case we need to revert any changes
        if (coinsDoubled) {
            coins += 2;
            Debug.Log("Coin (with multiplier) collected");
        } else {
            coins += 1;
            Debug.Log("Coin collected");
        }
    } */

    public int getLevel() {
        return currLevel;
    }

    private void CalculatePercentage()
    {
        // Calculate the current progress percentage
        currentPercentage = Mathf.Clamp((int)(((float)currentProgress / totalProgressCheckpoints) * 100f), 0, 100);

        progressText.SetText(currentPercentage.ToString() + "%");

        // Display the current percentage value
        // Debug.Log("Current Progress Percentage: " + currentPercentage.ToString("F2") + "%");
    }

    public void EnableShooting()
    {
        Debug.Log("Rocket launcher obtained");
        canShoot = true; // Player can now shoot
    }

    public void ActivateInvincibility()
    {
        isInvincible = true;
        Debug.Log("Activated Invincibility");
    }

    public void DeactivateInvincibility() {
        isInvincible = false;
        Debug.Log("Deactivated Invincibility");
    }

    /*
    public void ActivateCoinMultiplier()
    {
        coinsDoubled = true;
        Debug.Log("Activated coin multiplier");
    }

    public void DeactivateCoinMultiplier() {
        coinsDoubled = false;
        Debug.Log("Deactivated coin multiplier");
    }
    */

    public void ActivateTimewarp()
    {
        timewarpActive = true;
        countdownTimer.StartCountdown(5f);
        Debug.Log("Activated Timewarp");
    }

    public void DeactivateTimewarp() {
        timewarpActive = false;
        Debug.Log("Deactivated Timewarp");
    }

    private void TryShoot()
    {
        if (canShoot)
        {
            ShootProjectile();
            Debug.Log("Rocket Fired");
        }
    }

    private void ShootProjectile()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 2f;
        Instantiate(rocketLauncherPrefab, spawnPosition, transform.rotation);
        canShoot = false;
    }

    private void ApplyDriftFriction()
    {
        rearDriverW.sidewaysFriction = driftRearWFriction;
        rearPassengerW.sidewaysFriction = driftRearWFriction;
        frontDriverW.sidewaysFriction = driftRearWFriction;
        frontPassengerW.sidewaysFriction = driftRearWFriction;


    }

    private void RevertOriginalFriction()
    {
        rearDriverW.sidewaysFriction = originalRearWFriction;
        rearPassengerW.sidewaysFriction = originalRearWFriction;
    }
        
}
