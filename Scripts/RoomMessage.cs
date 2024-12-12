using UnityEngine;
using UnityEngine.UI; // For the Text UI element

public class RoomMessage : MonoBehaviour
{
    public string message; // The message to display
    public Text uiText; // Reference to the UI Text element
    public float disappearDelay = 2f; // Time after movement starts before the message disappears

    private bool playerInRoom = false;
    private bool playerStartedMoving = false;
    private float movementTimer = 0f;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        if (uiText != null)
        {
            uiText.text = ""; // Ensure the text starts empty
        }
    }

   void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player")) // Make sure the collider belongs to the player
    {
        playerInRoom = true;
        playerStartedMoving = false;
        movementTimer = 0f;

        if (uiText != null)
        {
            uiText.text = message; // Display the message
        }

        lastPlayerPosition = other.transform.position; // Store the player's initial position
    }
}

void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        playerInRoom = false;

        if (uiText != null)
        {
            uiText.text = ""; // Clear the message
        }
    }
}


    void Update()
    {
        if (playerInRoom)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                Vector3 currentPlayerPosition = player.transform.position;

                // Check if the player has started moving
                if (currentPlayerPosition != lastPlayerPosition)
                {
                    playerStartedMoving = true;
                }

                if (playerStartedMoving)
                {
                    movementTimer += Time.deltaTime;

                    if (movementTimer >= disappearDelay && uiText != null)
                    {
                        uiText.text = ""; // Clear the message
                    }
                }

                lastPlayerPosition = currentPlayerPosition; // Update the last position
            }
        }
    }
}
