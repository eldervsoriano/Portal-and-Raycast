using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Rigidbody2D playersRb;
    public PlayerController2D playercontroller2d;
    public Rigidbody2D boxRb;
    public float velocityX;
    public float velocityY;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersRb.velocity = new Vector2(velocityX, velocityY);
            playercontroller2d.enabled = false;
        }

        if (other.CompareTag("Box"))
        {
            boxRb.velocity = new Vector2(velocityX, velocityY);
        }
    }

    void PlayerScriptEnabler()
    {
        playercontroller2d.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("PlayerScriptEnabler", 1f);
        }
    }
}