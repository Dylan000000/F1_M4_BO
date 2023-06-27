using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathscreenUI : MonoBehaviour
{
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void gameoverscreen() 
    {
        gameOverUI.SetActive(true);
    }
    public void restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
        Time.timeScale = 1f;
    }
    public void mainMenu () 
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("mainMenu");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit(); 
        Debug.Log("Quit");
        Time.timeScale = 1f;
    }
}
