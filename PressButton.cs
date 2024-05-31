using UnityEngine;

public class PressButton : MonoBehaviour
{
    // Tag of the player object
    public string playerTag = "Player";

    // Tag of the box object
    public string boxTag = "Box";

    // The GameObject to activate and deactivate
    public GameObject objectToActivate;

    // This function is called when another collider enters the trigger collider attached to the object where this script is attached.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.CompareTag(playerTag) || collision.CompareTag(boxTag))
        {
            // Check if the target object is specified
            if (objectToActivate != null)
            {
                // Activate the target object
                objectToActivate.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No target object specified for activation.");
            }
        }
    }

    // This function is called when another collider exits the trigger collider attached to the object where this script is attached.
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.CompareTag(playerTag) || collision.CompareTag(boxTag))
        {
            // Check if the target object is specified
            if (objectToActivate != null)
            {
                // Deactivate the target object
                objectToActivate.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No target object specified for deactivation.");
            }
        }
    }
}
