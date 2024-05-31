using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public GameObject objectToActivate;
    public float activationDistance = 0.5f; // Adjust this value to set the activation distance

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsPlayerNear())
        {
            objectToActivate.SetActive(!objectToActivate.activeSelf);
        }
    }

    bool IsPlayerNear()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= activationDistance;
        }
        return false;
    }
}
