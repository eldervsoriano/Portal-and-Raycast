using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePortal : MonoBehaviour
{
    public Transform targetPos;
    public Transform playerPos;
    public Transform boxPressurePos;

    public Rigidbody2D playersRb;
    public Rigidbody2D boxRb;
    public PlayerController2D playerController;

    public float speedY;
    public float speedX;

    private Dictionary<Transform, float> jumpHeights = new Dictionary<Transform, float>();

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController2D>();
    }

    public void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerController.canTeleport == true)
        {
            playerController.canTeleport = false;
            playerPos.position = targetPos.position;

            // Store the player's jump height if it's a player
            jumpHeights[collision.transform] = playersRb.velocity.y;
        }
        else if (collision.gameObject.CompareTag("Box"))
        {
            boxRb = collision.GetComponent<Rigidbody2D>();
            boxRb.transform.position = targetPos.position;

            // Store the box's velocity
            jumpHeights[collision.transform] = boxRb.velocity.y;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerController.canTeleport == false)
        {
            Invoke("CanTP", 0.1f);
        }
        else if (collision.gameObject.CompareTag("Box"))
        {
            // Remove the stored velocity entry for the box
            if (jumpHeights.ContainsKey(collision.transform))
            {
                jumpHeights.Remove(collision.transform);
            }
        }
    }

    public void CanTP()
    {
        playerController.canTeleport = true;
    }

    private void ApplyThrowForce(Transform objTransform, float storedVelocity)
    {
        Rigidbody2D rb = objTransform.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 throwDirection = new Vector2(1f, 1f); // Change this to the desired throw direction
            rb.velocity = new Vector2(rb.velocity.x, storedVelocity); // Apply the stored velocity to simulate the throw
        }
    }
}
