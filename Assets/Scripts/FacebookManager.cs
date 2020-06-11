using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FacebookManager : MonoBehaviour
{
    public static FacebookManager Instance { get; private set; }

    // Awake function from Unity's MonoBehavior
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    public void LevelEnded(int level)
    {
        var parameters = new Dictionary<string, object>();
        parameters["Level number"] = level;
        FB.LogAppEvent(
            "Level Compled",
            parameters : parameters
        );
    }
    
    public void AddScore(int scorePlus)
    {
        var parameters = new Dictionary<string, object>();
        parameters["number of score"] = scorePlus;
        FB.LogAppEvent(
            "Score Added",
            parameters : parameters
        );
    }
}
