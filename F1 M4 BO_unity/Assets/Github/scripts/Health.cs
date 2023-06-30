using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public int numOfHearts;
    public Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Vector3 spawnpoint;
    public DeathscreenUI gameManager;
    public GameObject hurtcanvas;

    private bool isHurt;

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < health)
            {
                heartImages[i].sprite = fullHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag.ToLower().Trim();

        switch (tag)
        {
            case "spikes":
            case "enemy":
                health -= 1;
                Debug.Log("Health reduced! Current health: " + health);
                Debug.Log("Collision occurred!");
                ActivateHurtCanvas();
                if (health <= 0)
                {
                    gameManager.gameoverscreen();
                    Debug.Log("ded");
                    Time.timeScale = 0f;
                }
                break;
            case "medkit":
                health += 2;
                if (health > 6)
                {
                    health = 6;
                }
                Debug.Log("health up");
                break;
            case "strong enemy":
                health -= 2;
                ActivateHurtCanvas();
                if (health <= 0)
                {
                    gameManager.gameoverscreen();
                    Debug.Log("ded");
                    Time.timeScale = 0f;
                }
                break;
            case "healflower":
                health += 6;
                if (health > 6)
                {
                    health = 6;
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D  " + other.name);
        if (other.gameObject.CompareTag("Healflower"))
        {
            health += 6;
            Debug.Log("Health increased! Current health: " + health);
        }
        if (other.gameObject.CompareTag("Spikes"))
        {
            health -= 1;
            Debug.Log("Health reduced! Current health: " + health);
            ActivateHurtCanvas();
            if (health <= 0)
            {
                gameManager.gameoverscreen();
                Debug.Log("ded");
                Time.timeScale = 0f;
            }
        }
    }

    void ActivateHurtCanvas()
    {
        if (!isHurt)
        {
            isHurt = true;
            hurtcanvas.SetActive(true);
            StartCoroutine(DeactivateHurtCanvas());
        }
    }

    IEnumerator DeactivateHurtCanvas()
    {
        yield return new WaitForSeconds(0.2f);
        hurtcanvas.SetActive(false);
        isHurt = false;
    }
}
