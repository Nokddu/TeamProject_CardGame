using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager uiInstance;//다른 스크립트에서 사용하기위함
    public Text Timetxt; // ���� ������ �ð�
    public Text ScoreTxt;
    public GameObject normalClearEnd; //노말게임 성공시 나오는 사진과 글
    public GameObject normalFailEnd;//노말게임 실패시 나오는 사진과 글
    public GameObject timerGameEnd;//시간 제한모드 게임 종료시 나오는 글
    public GameObject EndPanel; // ������ ������ ������ �ǳ�

    private float Timer = 0f;

    private Text clearMsg;
    private Image clearImage;

    private bool resultShown = false;

    void Start()
    {
        Timetxt.gameObject.GetComponent<Text>();
        uiInstance = this;
        normalClearEnd.gameObject.SetActive(false);
        normalFailEnd.gameObject.SetActive(false);
        timerGameEnd.gameObject.SetActive(false);
        resultShown = false;
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;
        float t = Mathf.Clamp01(Timer / GameManager.instance.TimeSet);
        float whitetored = Mathf.Lerp(1f, 0f, t);
        Timetxt.color = new Color(1f, whitetored, whitetored);
        Timetxt.text = GameManager.instance.TimeSet.ToString("N1");
        ScoreTxt.text = GameManager.instance.Score.ToString();

        if(GameManager.instance.TimeSet <= 0f)
        {
            End();
        }
    }

    public void End()
    {
        if (resultShown) return;

        EndPanel.SetActive(true);
        if ( GameManager.instance._state == GameManager.TimedOrScore.Timed) //게임타입이 일반게임인경우
        {
            if (GameManager.instance.TimeSet > 0)
            {
                normalClearEnd.gameObject.SetActive(true);
                CollectMember();
            }
            else if(GameManager.instance.TimeSet <= 0)
            {
                normalFailEnd.gameObject.SetActive(true);
            }
        }
        else //게임타입이 시간제한모드인경우
        {
            timerGameEnd.gameObject.SetActive(true);
        }
        resultShown = true; //결과 보여줬다고 표시
    }


    public void Retry() // 다시 시작 버튼 
    {
        GameManager.instance.GoTitle();  // 다시 시작 버튼 나오면 게임 매니저에 따로 loadscene 만들 예정
    }
    public void MoveTitle()
    {
        GameManager.instance.GoTitle(); // 타이틀 씬 이동
    }
    public void EndButton() //실제로는 게임 종료되지만 화면상에는 안꺼짐
    {
        GameManager.instance.ExitBtn(); // 게임 종료 함수 종료는 되는데 아마 지금 안먹음
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
        if (imageObject != null)
        {
            clearImage = imageObject.GetComponent<Image>();
        }
        else
        {
            Debug.Log("ClearImage못찾음");
        }
        Debug.LogWarning("SetupMainSceneUI() is called");
    }

    public void CollectMember()    //멤버 수집 (중복제외) 수집된 멤버는 List에서 제거하는 방식으로 중복 방지함.
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (GameManager.collectedCards.Count != GameManager.teamMembers.Count) //다 못 모았을 때
            {
                bool isCollected = false;
                string memberName;

                do
                {
                    int index = Random.Range(0, GameManager.teamMembers.Count);
                    memberName = GameManager.teamMembers[index];
                    isCollected = GameManager.collectedCards.Contains(memberName);
                } while (isCollected); //중복 체크

                GameManager.collectedCards.Add(memberName);

                if (clearMsg == null || clearImage == null)
                {
                    Debug.LogWarning("CollectMember(): UI가 아직 설정되지 않았습니다.");
                    SetupMainSceneUI();
                }
                clearMsg.text = memberName + "을 획득했다!";
                clearImage.sprite = Resources.Load<Sprite>(memberName + "_" + 1);
                Debug.Log("CollectMember called");
            }
            else if (GameManager.collectedCards.Count == GameManager.teamMembers.Count) //다 모았을 때
            {
                if (clearMsg == null || clearImage == null)
                {
                    Debug.LogWarning("CollectMember(): UI가 아직 설정되지 않았습니다.");
                    SetupMainSceneUI();
                }
                clearMsg.text = "이미 모두 획득했다!";
                clearImage.sprite = Resources.Load<Sprite>("cryingcat");
            }
        }
    }
}

