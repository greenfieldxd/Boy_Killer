using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    #region Singleton
    public static ScenesLoader Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }
    #endregion

    public void RestartLevel(float delay)
    {
        StartCoroutine(ReloadLevelWithDelay(delay));
    }

    public void LoadNextLevel(float delay)
    {
        StartCoroutine(LoadNextLevelWithDelay(delay));
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    IEnumerator ReloadLevelWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    IEnumerator LoadNextLevelWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
