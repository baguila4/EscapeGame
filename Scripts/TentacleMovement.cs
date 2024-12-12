using UnityEngine;

public class TentacleMovement : MonoBehaviour
{
    public Vector3 movementOffset; // Offset to move the tentacle, e.g., (0, 3, 0) for up/down
    public float moveDuration = 3f; // Time to stay in the moved position

    private Vector3 originalPosition; // To store the tentacle's original position
    private bool isMovingToOffset = true; // Track movement direction
    private float timer = 0f; // Timer for switching states

    void Start()
    {
        // Store the original position at the start
        originalPosition = transform.position;
    }

    void Update()
    {
        // Increment the timer with the time elapsed since the last frame
        timer += Time.deltaTime;

        if (timer >= moveDuration)
        {
            // Reset the timer and toggle the movement direction
            timer = 0f;
            isMovingToOffset = !isMovingToOffset;
        }

        // Calculate the target position based on the movement state
        Vector3 targetPosition = isMovingToOffset ? originalPosition + movementOffset : originalPosition;

        // Smoothly move towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * (1 / moveDuration));
    }
}