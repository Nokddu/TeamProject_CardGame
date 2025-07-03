using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤
    
    public static string gameType = "Normal";
    public Card firstCard; 
    public Card secondCard;
    public bool allOpen = false;
    public int cardCount = 0;

    public List<Card> allCards = new List<Card>();//전체 카드 리스트
    public float TimeSet { get; private set; } // timeset 변수에 관한 get set 정보 받아오기만 가능하게 실직적 값 변환은 gamemanager에서
    public int Score { get; private set; }  // 위와 같음 score 모드 만들어지면 스테이트에 추가할 예정

    public int BestScore { get; private set; }

    public static List<string> collectedCards = new List<string>(); //수집된 멤버들 add 될 예정.
    private AudioSource audioSource;
    public AudioClip matchSound;
    private Text clearMsg;
    private Image clearImage;


    //State 패턴
    public enum TimedOrScore
    {
        Timed, // 시간안에 다 맞추는 모드 . 아마 Default라고 생각
        Score // TimeSet 안에 최대한 많이 뒤집는 모드
    }

    public TimedOrScore _state = TimedOrScore.Timed;

    List<string> teamMembers = new List<string> { "Yejin", "YongMin", "Younga", "Youngsik" };
    
    public void SetStateToggle(bool isOn) // bool 값을 받아서 state 값 조정
    {
        _state = isOn ? TimedOrScore.Score : TimedOrScore.Timed; // state에 대한 람다식 isOn ? True 면 score 모드로 Toggle Check : false면 Timed 모드로 << 현재 default 값이 Timed;
        Debug.Log(_state); // 현재 스테이트 디버깅용
    }
   

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // 혹시 모를 게임매니저 복제 대응
        }
    }


    void Start()
    {
        DontDestroyOnLoad(gameObject); // 게임매니저는 하나밖에 없으니 타이틀에서 넘어가도 안사라지게
        Time.timeScale = 1f; // 시작할 때 timescale 초기화
        _state = TimedOrScore.Timed; // state도 시작할 때 timed 로 초기화 << default

        StartCoroutine(DelayAndShowAllCards());
    }

    void Update()
    {
        //Debug.Log(TimeSet);
        if(TimeSet < 0f)
        {
            GameEnd();
        }
    }

    public void StartGame() // 함수 실행되면 스테이트에 맞는 함수 실행되게
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

    void TimedMod() // Coroutine을 스테이트에 맞는 시간만큼 주고 시작
    {
        StartCoroutine(timeCal(100f));
    }

    void ScoreMod() // 위와 같음
    {
        StartCoroutine(timeCal(120f));
    }

    private IEnumerator timeCal(float x) // 시간 계산용 코루틴 float x 에 받은 값만큼 세팅된다
    {
        TimeSet = x;

        while(TimeSet > 0f)
        {
            TimeSet -= Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator DelayAndShowAllCards() // 카드가 모두 생성될 시간 확보하는 함수
    {
        yield return new WaitForSeconds(1.0f);
        ShowAllCardsOnce();
    }
    public void isMatched()
    {
        allOpen = true;
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(matchSound);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            Invoke(nameof(EnableClick), 1.0f);

            if(_state == TimedOrScore.Score)
            {
                Score += 100;
<<<<<<< Updated upstream
=======
                if(cardCount == -14)
                {
                    cardCount = 0;
                    foreach(Card card in allCards)
                    {
                        card.gameObject.SetActive(true);
                        card.CloseCardInvoke();
                    }
                }
>>>>>>> Stashed changes
            }

            if(_state == TimedOrScore.Timed)
            {
                if (cardCount == -14)
                { // 카드를 모두 찾을시
                    Time.timeScale = 0.0f;
                    Invoke("EndButton", 1.0f);
                    UIManager.uiInstance.End();
                    CollectMember();
                    Debug.Log("이겼다. 카드 얻으러가자");
                }
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
    public void DiscountTime(float seconds)
    {
        TimeSet -= seconds;
        if (TimeSet < 0f)
        {
            TimeSet = 0f;
            UIManager.uiInstance.End(); // 시간이 0이 되면 즉시 게임 종료 처리
        }
    }
    void EnableClick()
    {
        allOpen = false;
    }

    public void ShowAllCardsOnce()
    {
        StartCoroutine(ShowAllCardsCoroutine());
    }

    IEnumerator ShowAllCardsCoroutine()
    {
        allOpen = true; //활성화 되어있는 동안 플레이어가 카드 클릭 못하도록함

        // 모든 카드 앞면 표시
        foreach (Card card in allCards)
        {
            card.ShowCardFace();
        }

        // n초 보여주기
        yield return new WaitForSeconds(2f);

        // 모든 카드 닫기
        foreach (Card card in allCards)
        {
            card.HideCardFace();
        }

        allOpen = false;
    }
    void GameEnd() // 게임이 끝날 시 타임 스케일 변경 : 시간을 멈춤
    {
        Time.timeScale = 0f;
        TimeSet = 0f;
        cardCount = 0;
        if (Score > BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetInt("BestScore", BestScore);
            PlayerPrefs.Save();
        }
        StopAllCoroutines();
    }

    public void GoTitle() // 타이틀로 가게 될시 타임 스케일 다시 1f 시작했던 코루틴들 다 멈추게 하기
    {
        Time.timeScale = 1f;
        TimeSet = 0f;
        Score = 0;
        cardCount = 0;
        StopAllCoroutines();
        SceneManager.LoadScene("TitleScene");
    }

    public void ExitBtn() // 게임 종료
    {
        Application.Quit();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) //Scene로드 되었을 때 실행
    {
        if (scene.name == "MainScene")
        {
            SetupMainSceneUI();
        }
    }

    private void SetupMainSceneUI() //MainScene에만 있는 오브젝트 참조용.
    {
        GameObject textObject = GameObject.Find("ClearMsg");
        if (textObject != null)
        {
            clearMsg = textObject.GetComponent<Text>();
        }
        else
        {
            Debug.Log("ClearMsg못찾음");
        }

        GameObject imageObject = GameObject.Find("ClearImage");
        if(imageObject != null)
        {
            clearImage = imageObject.GetComponent<Image>();
        }
        else
        {
            Debug.Log("ClearImage못찾음");
        }
    }

    void CollectMember()    //멤버 수집 (중복제외) 수집된 멤버는 List에서 제거하는 방식으로 중복 방지함.
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            int index = Random.Range(0, teamMembers.Count);
            string memberName = teamMembers[index];
            teamMembers.RemoveAt(index);
            collectedCards.Add(memberName);

            if (clearMsg == null || clearImage == null)
            {
                Debug.LogWarning("CollectMember(): UI가 아직 설정되지 않았습니다.");
                SetupMainSceneUI();
            }

            clearMsg.text = memberName + "을 획득했다!";
            clearImage.sprite = Resources.Load<Sprite>(memberName + "_" + 1);
            Debug.Log("CollectMember called");
        }
    }
<<<<<<< Updated upstream
=======

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        allCards.Clear();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
>>>>>>> Stashed changes
}

