using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPortal : MonoBehaviour
{
    // Tag of the player object
    public string playerTag = "Player";

    // The name of the scene to load
    public string targetSceneName;

    // This function is called when another collider enters the trigger collider attached to the object where this script is attached.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.CompareTag(playerTag))
        {
            // Check if a target scene name is specified
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                // Load the target scene
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("No target scene name specified for the portal.");
            }
        }
    }
}
