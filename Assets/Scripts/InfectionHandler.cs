using UnityEngine;

public class InfectionHandler : MonoBehaviour
{
    public Status currentStatus = Status.Healthy; // Default status
    private SpriteRenderer spriteRenderer;

    public Color healthyColor = Color.green;
    public Color sickColor = Color.red;
    public Color immuneColor = Color.blue;
    public Color deadColor = Color.black;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    public void UpdateColor()
    {
        if (spriteRenderer == null) return;

        switch (currentStatus)
        {
            case Status.Healthy: spriteRenderer.color = healthyColor; break;
            case Status.Sick: spriteRenderer.color = sickColor; break;
            case Status.Immune: spriteRenderer.color = immuneColor; break;
            case Status.Dead: spriteRenderer.color = deadColor; break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debugging: Log all collisions
        Debug.Log($"{gameObject.name} collided with {other.gameObject.name}");

        // Only sick humans can infect others
        if (currentStatus != Status.Sick) return;

        // Get the InfectionHandler from the other object
        InfectionHandler otherHandler = other.GetComponent<InfectionHandler>();

        // Only infect Healthy humans
        if (otherHandler != null && otherHandler.currentStatus == Status.Healthy)
        {
            Debug.Log($"{gameObject.name} infected {other.gameObject.name}.");
            otherHandler.ChangeStatus(Status.Sick);
        }
    }

    public void ChangeStatus(Status newStatus)
    {
        if (currentStatus == newStatus || currentStatus == Status.Dead) return; // No redundant changes

        currentStatus = newStatus;
        UpdateColor();
    }
}
