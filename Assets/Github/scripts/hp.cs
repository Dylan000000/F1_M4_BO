using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    public int health = 6;
    public DeathscreenUI gameManager;
    private bool isdead;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spikes")) 
        {
            health -= 1;
            Debug.Log(health);
        }
            if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            Debug.Log("Health reduced! Current health: " + health);
            Debug.Log("Collision occurred!");
        }
        if (collision.gameObject.CompareTag("Medkit"))
        {
            health += 2;
            Debug.Log("Health increased! Current health: " + health);
        }
        if (collision.gameObject.CompareTag("Healflower"))
        {
            health += 6;
            Debug.Log("Health increased! Current health: " + health);
        }
        if (health > 6)
        {
            health = 6;
        }
        if (collision.gameObject.CompareTag("Strong Enemy"))
        {
            health -= 2;
            Debug.Log("Health reduced! Current health: " + health);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 2;
            Debug.Log("Health reduced! Current health: " + health);
        }
            void OnTriggerEnter(Collider other) 
        {
            if (collision.gameObject.CompareTag("Spikes"))
            {
                health -= 1;
                Debug.Log(health);
            }
        }



        if (health <= 0 && !isdead)
        {
            isdead= true;
            gameManager.gameoverscreen();
            Debug.Log("ded");
        }
    }

    void Update()
    {
    }
}
