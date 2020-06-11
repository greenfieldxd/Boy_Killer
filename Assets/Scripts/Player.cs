using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player Instance { get; private set; }
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

    public int ammo { get; private set; }


    [Header("Player config")]
    [SerializeField] int numberAmmo = 2; //Количество патронов

    [Header("References")]
    [SerializeField] GameObject buttonShot;
    [SerializeField] GameObject LosePanel;
    [SerializeField] Text ammoText;

    [Header("Config Sequence")]
    [SerializeField] float moveTimeFirst = 6f;
    [SerializeField] float moveTimeSecond = 6f;
    [SerializeField] float moveTimeThird = 6f;
    [SerializeField] float moveTimeFour = 6f;
    [SerializeField] float moveTimeFifth = 6f;
    [SerializeField] float moveTimeSixth = 6f;
    [SerializeField] float moveTimeSeventh = 6f;
    [SerializeField] float moveTimeEighth = 6f;
    [Header("")]
    [SerializeField] float rotateTime = 3f;
    [SerializeField] float jumpPower = 3f;
    [Header("")]
    [SerializeField] float firstPos;
    [SerializeField] float secondPos;
    [SerializeField] float thirdPos;
    [SerializeField] float fourPos;
    [SerializeField] float fifthPos;
    [SerializeField] float sixthPos;
    [SerializeField] float seventhPos;
    [SerializeField] float eighthPos;
    [SerializeField] Vector3 firstRotate;

    Sequence mySequence;

    int currentLevel;


    public void MinusAmmo()
    {
        ammo--;
        ammoText.text = "Ammo: " + ammo;
        if (ammo <= 0)
        {
            Time.timeScale = 1f;
            buttonShot.SetActive(false);
        }
    }



    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        ammo = numberAmmo;
        ammoText.text = "Ammo: " + ammo;

        mySequence = DOTween.Sequence()
            .Append(transform.DORotate(new Vector3(0, 45, 0), 0.5f))
            .Append(transform.DORotate(new Vector3(0, 0, 0), 0.5f))
            .Append(transform.DOMoveX(firstPos, moveTimeFirst)).SetEase(Ease.InOutSine)
            .Append(transform.DOJump(new Vector3(firstPos + 2f, 1, 0), jumpPower, 1, 1f))
            .Append(transform.DOMoveX(secondPos, moveTimeSecond)).SetEase(Ease.InSine)
            .Append(transform.DOJump(new Vector3(secondPos + 2f, 2, 0), jumpPower, 1, 1f))
            .Append(transform.DOMoveX(thirdPos, moveTimeThird)).SetEase(Ease.InSine)
            .Append(transform.DOJump(new Vector3(thirdPos + 2f, 3, 0), jumpPower, 1, 1f))
            .Append(transform.DOMoveX(fourPos, moveTimeFour)).SetEase(Ease.InSine)
            .AppendCallback(PlayerCanShoot)
            .Append(transform.DOJump(new Vector3(fourPos + 6f, 3, 0), 5f, 1, 6f)).OnComplete(() => Time.timeScale = 1f)
            .Join(transform.DORotate(firstRotate, rotateTime, RotateMode.FastBeyond360))
            .Append(transform.DOMoveX(fifthPos, moveTimeFifth)).SetEase(Ease.InSine)
            .Append(transform.DOJump(new Vector3(fifthPos + 2f, 2, 0), jumpPower - 0.3f, 1, 1f))
            .Append(transform.DOMoveX(sixthPos, moveTimeSixth)).SetEase(Ease.InSine)
            .Append(transform.DOJump(new Vector3(sixthPos + 2f, 1, 0), jumpPower - 0.3f, 1, 1f))
            .Append(transform.DOMoveX(seventhPos, moveTimeSeventh)).SetEase(Ease.InSine)
            .Append(transform.DOJump(new Vector3(seventhPos + 2f, 0, 0), jumpPower - 0.3f, 1, 1f))
            .Append(transform.DOMoveX(eighthPos, moveTimeEighth)).SetEase(Ease.InSine)
            .AppendCallback(PlayerCanNotShoot);
    }

    void PlayerCanShoot()
    {
        Time.timeScale = 0.4f;
        buttonShot.SetActive(true);
    }

    void PlayerCanNotShoot()
    {
        Time.timeScale = 1f;
        buttonShot.SetActive(false);
        CheckWinOrLose();
     }

    void CheckWinOrLose()
    {
        if (GameManager.Instance.score >= GameManager.Instance.levelPoints)
        {
            ScenesLoader.Instance.LoadNextLevel(1f);
            FacebookManager.Instance.LevelEnded(currentLevel);//Event facebook 
        }
        else
        {
            LosePanel.SetActive(true);
            GameManager.Instance.RestartGame();
        }
    }

}
