using UnityEngine;

public class CarFollowPlayer : MonoBehaviour
{
    public float speed = 5f; // Speed of the car.
    public float minimumDistance = 5f; // Minimum distance to maintain from player.
    private Transform playerTransform; // To store the player's transform.

    void Start()
    {
        // Find the player object by tag and store its transform.
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if playerTransform is not null to avoid errors if the player is not found.
        if(playerTransform != null)
        {
            // Calculate the direction to the player.
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.y = 0; // Ignore the y-axis to keep the movement horizontal.

            // Calculate the distance to the player.
            float distanceToPlayer = directionToPlayer.magnitude;

            // Check if the car is further away than the minimum distance.
            if(distanceToPlayer > minimumDistance)
            {
                // Normalize the direction vector, and move the car towards the player.
                Vector3 moveDirection = directionToPlayer.normalized;
                transform.position += moveDirection * speed * Time.deltaTime;

                // Optionally, make the car face the player.
                transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
            }
        }
    }
}
