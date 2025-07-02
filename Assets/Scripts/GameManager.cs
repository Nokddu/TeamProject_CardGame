using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static string gameType = "Normal";
    public Card firstCard;
    public Card secondCard;
    public bool allOpen = false;
    public int cardCount = 0;

    public float TimeSet { get; private set; }
    public int Score { get; private set; } 
    //State 패턴
    public enum TimedOrScore
    {
        Timed,
        Score
    }
    public TimedOrScore _state = TimedOrScore.Timed;

    public void SetStateToggle(bool isOn)
    {
        _state = isOn ? TimedOrScore.Score : TimedOrScore.Timed;
        Debug.Log(_state);
    }
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
        _state = TimedOrScore.Timed;
    }

    void Update()
    {
        Debug.Log(TimeSet);

        if(TimeSet < 0f)
        {
            GameEnd();
        }
    }

    public void StartGame()
    {
        switch (_state)
        {
            case TimedOrScore.Timed:
                TimedMod();// 시간안에 모든 카드 뒤집기
                break;
            case TimedOrScore.Score:
                ScoreMod();// 시간안에 최대한 많은 카드 뒤집기
                break;
        }
    }

    void TimedMod()
    {
        StartCoroutine(timeCal(30f));
    }

    void ScoreMod()
    {
        StartCoroutine(timeCal(120f));
    }

    private IEnumerator timeCal(float x)
    {
        TimeSet = x;

        while(TimeSet > 0f)
        {
            TimeSet -= Time.deltaTime;
            yield return null;
        }
    }

    public void isMatched()
    {
        allOpen = true;
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            Invoke(nameof(EnableClick), 1.0f);
            if (cardCount == -16)
            { // 카드를 모두 찾을시
                Time.timeScale = 0.0f;
                Invoke("EndButton", 1.0f);
                UIManager.uiInstance.End();
            }

        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();

            Invoke(nameof(EnableClick), 1.0f);

        }


        firstCard = null;
        secondCard = null;

        allOpen = true;



    }

    void EnableClick()
    {
        allOpen = false;
    }


    void GameEnd()
    {
        Time.timeScale = 0f;
    }

    public void GoTitle()
    {
        Time.timeScale = 1f;
        StopAllCoroutines();
        SceneManager.LoadScene("TitleScene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}

