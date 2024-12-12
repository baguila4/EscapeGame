using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    [SerializeField] private int fuelValue = 1; // The amount of fuel this pickup provides
    [SerializeField] private Door targetDoor; // Reference to the door/rocket script this fuel contributes to
    public SFXManager sfxManager; // Reference to the SFXManager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetDoor.CollectFuel(fuelValue);
            sfxManager.PlaySound("fuel");
            Destroy(gameObject);
        }
    }
}
