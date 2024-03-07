using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public float rotateSpeed = 1f;
    private float targetAngle = 80f;
    private float currentAngle = 0f;
    private bool rotatingRight = true;

    void Update()
    {
        if (rotatingRight)
        {
            if (currentAngle < targetAngle)
            {
                // Rotate right
                currentAngle += rotateSpeed * Time.deltaTime;
                if (currentAngle > targetAngle)
                {
                    currentAngle = targetAngle; // Clamp to target to avoid overshooting
                }
            }
            else
            {
                // Once the target angle is reached, prepare to rotate back
                rotatingRight = false;
            }
        }
        else
        {
            if (currentAngle > 0)
            {
                // Rotate back/left
                currentAngle -= rotateSpeed * Time.deltaTime;
                if (currentAngle < 0)
                {
                    currentAngle = 0; // Clamp to avoid overshooting
                }
            }
            else
            {
                // Once original orientation is reached, prepare to rotate right again
                rotatingRight = true;
            }
        }

        // Apply rotation
        transform.rotation = Quaternion.Euler(0, currentAngle, 0);
    }
}
