using UnityEngine;

public class MaintainScale : MonoBehaviour
{
    public float baseScale = 1f; // Base scale size you want to maintain

    void LateUpdate()
    {
        // Preserve the x scale sign for flipping
        float currentXScale = Mathf.Sign(transform.localScale.x) * baseScale;

        // Lock the scale
        transform.localScale = new Vector3(currentXScale, baseScale, baseScale);
    }
}
