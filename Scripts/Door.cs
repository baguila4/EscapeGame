using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject currentPlayer;
    [SerializeField] private GameObject nextPlayer;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private bool isEndDoor = false;
    [SerializeField] private int requiredFuel = 0; // Fuel required for this door
    public SFXManager sfxManager; // Reference to the SFXManager

    private int collectedFuel = 0; // Tracks fuel collected for this door

    // Method to add collected fuel for this specific door
    public void CollectFuel(int fuelAmount)
    {
        collectedFuel += fuelAmount;
        Debug.Log($"Door {gameObject.name} - Collected Fuel: {collectedFuel}/{requiredFuel}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == currentPlayer)
        {
            // Check if the required fuel for this door has been collected
            if (collectedFuel >= requiredFuel)
            {
                if (isEndDoor)
                {
                    SceneManager.LoadScene("EndScreen");
                    Debug.Log("Game Over! Loading End Screen...");
                                sfxManager.PlaySound("rocket");

                }
                else
                {
                    // Transition to the next room
currentPlayer.SetActive(false);
nextPlayer.SetActive(true);
nextPlayer.GetComponent<PlayerHealth>().SetAsActivePlayer(); // Make sure to set the next player as active
cameraController.MoveToNewRoom(nextRoom);
                                sfxManager.PlaySound("rocket");


                }
            }
            else
            {
                Debug.Log($"Door {gameObject.name} - Not enough fuel! Need {requiredFuel - collectedFuel} more.");
            }
        }
    }
}
