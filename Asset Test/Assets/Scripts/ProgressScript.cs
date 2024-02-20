using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressScript : MonoBehaviour
{
    public GameObject car; // Reference to the car GameObject

    private int totalProgressCheckpoints; // Total number of progress checkpoints
    private int currentProgress; // Current progress count
    private float currentPercentage; // Current progress percentage

    private void Start()
    {
        // Find all progress checkpoints with the tag "Progress"
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Progress");
        totalProgressCheckpoints = checkpoints.Length;
        Debug.Log(totalProgressCheckpoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering trigger");
        if (other.gameObject == car)
        {
            Debug.Log("Calculating stuff");
            currentProgress++;
            CalculatePercentage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == car)
        {
            currentProgress--;
            CalculatePercentage();
        }
    }

    private void CalculatePercentage()
    {
        // Calculate the current progress percentage
        currentPercentage = Mathf.Clamp((float)currentProgress / totalProgressCheckpoints * 100f, 0f, 100f);

        // Display the current percentage value
        Debug.Log("Current Progress Percentage: " + currentPercentage.ToString("F2") + "%");
    }
}
