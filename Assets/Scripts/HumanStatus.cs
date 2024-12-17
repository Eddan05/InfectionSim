using UnityEngine;
using System.Collections;

// Enum definition
public enum Status
{
    Healthy,
    Sick,
    Immune,
    Dead
}

// Class definition
public class HumanStatus : MonoBehaviour
{
    public Status currentStatus = Status.Healthy;

    public void ChangeStatus(Status newStatus)
    {
        if (currentStatus == Status.Dead)
        {
            // Dead objects cannot change their status.
            return;
        }

        currentStatus = newStatus;

        if (newStatus == Status.Dead)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        // Logic for when a human dies (e.g., stop movement, disable colliders).
        GetComponent<Collider2D>().enabled = false; // Prevent further interactions.
        // Additional death-related behavior can go here.
    }
}
