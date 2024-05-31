using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFalse : MonoBehaviour
{
    public float totalWeight = 0f;
    public GameObject Door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            totalWeight += collision.GetComponent<Rigidbody2D>().mass;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            totalWeight -= collision.GetComponent<Rigidbody2D>().mass;
        }
    }
    private void Update()
    {
        if (totalWeight >= 2)
        {
            Door.SetActive(false);
        }
        else
        {
            Door.SetActive(true);
        }
    }
}
