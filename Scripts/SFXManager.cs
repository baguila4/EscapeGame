using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSource;  

    public AudioClip deathSound;
    public AudioClip rocketTouchSound;
    public AudioClip fuelSound;

    // Method to play a specific sound
    public void PlaySound(string action)
    {
        switch (action)
        {
            case "death":
                audioSource.PlayOneShot(deathSound);
                break;
            case "rocket":
                audioSource.PlayOneShot(rocketTouchSound);
                break;
            case "fuel":
                audioSource.PlayOneShot(fuelSound);
                break;
        }
    }
}
