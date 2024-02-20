using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 200f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            print("rigidbody found");
            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
            rb.velocity = transform.forward * speed;

        }
        else
        {
            Debug.LogError("Rigidbody component missing from projectile prefab", this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject); // Destroy the obstacle
            Destroy(gameObject); // Destroy the projectile
        }
    }
}