using UnityEngine;
using System.Collections;

public class HumanMovement : MonoBehaviour
{
    public Vector2 minBounds; // Minimum X, Y boundary (bottom-left corner)
    public Vector2 maxBounds; // Maximum X, Y boundary (top-right corner)

    public float speed = 2f;
    private Vector2 direction;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        ChangeDirection();
        InvokeRepeating("ChangeDirection", 2f, 2f); // Change direction every 2 seconds
    }

    void Update()
    {
        // Get the current position
        Vector2 currentPosition = transform.position;

        // Clamp the position between the screen's world boundaries
        ClampPositionToScreenBounds(currentPosition);

        // Move the object
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void ClampPositionToScreenBounds(Vector2 currentPosition)
    {
        // Get the camera's viewport corners in world space
        Vector3 minWorld = Camera.main.ViewportToWorldPoint(Vector3.zero); // Bottom-left corner of the screen (0,0 in viewport)
        Vector3 maxWorld = Camera.main.ViewportToWorldPoint(Vector3.one);  // Top-right corner of the screen (1,1 in viewport)

        // Set min and max bounds based on camera's screen size
        minBounds = new Vector2(minWorld.x, minWorld.y);
        maxBounds = new Vector2(maxWorld.x, maxWorld.y);

        // Clamp the position between the minimum and maximum bounds
        float clampedX = Mathf.Clamp(currentPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(currentPosition.y, minBounds.y, maxBounds.y);

        // Set the clamped position
        transform.position = new Vector2(clampedX, clampedY);
    }

    void ChangeDirection()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}