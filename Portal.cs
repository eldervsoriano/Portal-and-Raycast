using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform targetPos;
    public float teleportCooldown = 1f; // Time in seconds before an object can be teleported again
    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTeleport && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box"))
        {
            StartCoroutine(TeleportWithCooldown(collision.transform));
        }
    }

    private IEnumerator TeleportWithCooldown(Transform objTransform)
    {
        canTeleport = false;

        // Teleport the object
        objTransform.position = targetPos.position;

        // Wait for the cooldown period
        yield return new WaitForSeconds(teleportCooldown);

        canTeleport = true;
    }
}
