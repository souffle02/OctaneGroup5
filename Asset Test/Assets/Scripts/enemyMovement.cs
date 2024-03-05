using Unity.VisualScripting;
using UnityEngine;

public class CarFollowPlayer : MonoBehaviour
{
    public float baseSpeed = 5f; // Base speed of the car.
    public float baseMinimumDistance = 5f; // Base minimum distance to maintain from player.
    private Transform playerTransform; // To store the player's transform.
    private Rigidbody rb; // Reference to the car's Rigidbody component.
    private float timeCounter = 0f; // Counter to track the elapsed time.

    void Start()
    {
        // Find the player object by tag and store its transform.
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the Rigidbody component from this GameObject.
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from this GameObject");
        }
    }

    void FixedUpdate()
    {
        // Use FixedUpdate for physics-based updates.
        // Update the time counter based on fixed time to keep consistent with physics updates.
        timeCounter += Time.fixedDeltaTime;

        // Oscillate the minimum distance using a sine wave.
        float minimumDistance = baseMinimumDistance + Mathf.Sin(timeCounter / 5 * Mathf.PI) * baseMinimumDistance;

        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.y = 0; // Keep the movement horizontal.

            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer > minimumDistance)
            {
                Vector3 moveDirection = directionToPlayer.normalized;
                Vector3 newPosition = rb.position + moveDirection * baseSpeed  *Time.fixedDeltaTime;

                // Use Rigidbody.MovePosition for smooth physics-based movement.
                rb.MovePosition(newPosition);

                // Face the player with a smooth rotation.
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(playerTransform.position.x, rb.position.y, playerTransform.position.z) - rb.position);
                rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, baseSpeed * Time.fixedDeltaTime));
                
            }
        }
    }
}
