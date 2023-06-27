using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public string mainGameSceneName = "MainGame";
    public float delay = 3f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            SwitchToMainGameScene();
        }
    }

    private void SwitchToMainGameScene()
    {
        SceneManager.LoadScene(mainGameSceneName);
    }
}

