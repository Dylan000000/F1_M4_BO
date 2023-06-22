using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Move the player object to the spawn point
            other.transform.position = spawnPoint.position;
        }
    }
}

