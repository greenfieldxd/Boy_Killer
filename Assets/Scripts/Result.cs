using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class Result : MonoBehaviour
{
    [SerializeField] Text resultText;
    void Start()
    {
        resultText.text = "Level Complete!!! Your score is " + GameManager.Instance.score;
    }

   
}
