using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Transform respawnPosition; // Starting position in the current scene
    public SFXManager sfxManager; // Reference to the SFXManager

    private static PlayerHealth currentActivePlayer; // Tracks the current active player

    private void Start()
    {
        if (respawnPosition == null)
        {
            respawnPosition = transform;
        }

        currentActivePlayer = this;
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadly"))
        {
            Die();
        }
    }

    void Die()
    {
        if (currentActivePlayer == this)
        {
            sfxManager.PlaySound("death");
            RespawnPlayer();
        }
        else
        {
            Debug.LogWarning("Inactive player died, no respawn needed.");
        }
    }

    void RespawnPlayer()
    {
        transform.position = respawnPosition.position;
        Debug.Log("Player has died and been respawned.");
    }

    public void SetAsActivePlayer()
    {
        currentActivePlayer = this;
        Debug.Log($"{gameObject.name} is now the active player.");
    }
}
