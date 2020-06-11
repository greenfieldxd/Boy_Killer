using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class GameManager : MonoBehaviour
{
  
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            score = 0;
            levelPoints = 0;
        }

    }
   

    public int score { get; private set; }
    public int levelPoints { get; private set; }

    private void Start()
    {
        score = 0;
    }

    public void AddScore()
    {
        score ++;
        FacebookManager.Instance.AddScore(1); //plus 1 score
    }
    public void AddLevelPoints()
    {
        levelPoints ++;
    }

    public void RestartGame()
    {
        score = 0;
        levelPoints = 0;
        //somthing else
    }
    
}
