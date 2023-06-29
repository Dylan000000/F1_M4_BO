using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spacepart_collect : MonoBehaviour
{
    public int coins;
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag.ToLower().Trim())
        {
            case "space_part":
                coins++;
                Destroy(collision.gameObject);
                if (coins >= 2)
                {
                    Debug.Log("load");
                    SceneManager.LoadScene("Level_02");
                }
                break;
            case "door":
                if (coins >= 2)
                {
                    SceneManager.LoadScene("Level_2");
                }
                break;
           }
    }
}
