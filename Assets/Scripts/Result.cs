using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class Result : MonoBehaviour
{
    [SerializeField] Text resultText;
    [SerializeField] GameObject buttonAds;

    void Start()
    {
        resultText.text = "Level Complete!!! Your score is " + GameManager.Instance.score;
    }

    public void PlayAds()
    {
        IronSourceManager.Instance.ShowAds();

        resultText.text = "Level Complete!!! Your score is " + GameManager.Instance.score;
        buttonAds.SetActive(false);

    }


}
