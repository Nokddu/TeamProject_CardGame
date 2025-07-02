using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager uiInstance;//다른 스크립트에서 사용하기위함
    public Text Timetxt; // ���� ������ �ð�
    public GameObject normalClearEnd; //노말게임 성공시 나오는 사진과 글
    public GameObject normalFailEnd;//노말게임 실패시 나오는 사진과 글
    public GameObject timerGameEnd;//시간 제한모드 게임 종료시 나오는 글
    public GameObject EndPanel; // ������ ������ ������ �ǳ�
    private float Timer = 0f;
    void Start()
    {
        Timetxt.gameObject.GetComponent<Text>();
        uiInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;
        float t = Mathf.Clamp01(Timer / GameManager.instance.TimeSet);
        float whitetored = Mathf.Lerp(1f, 0f, t);
        Timetxt.color = new Color(1f, whitetored, whitetored);
        Timetxt.text = GameManager.instance.TimeSet.ToString("N1");



        if(GameManager.instance.TimeSet < 0f)
        {
            End();
        }
    }

    public void End()
    {
        EndPanel.SetActive(true);
        if (GameManager.gameType == "Normal") //게임타입이 일반게임인경우
        {
            if (GameManager.instance.TimeSet > 0)
            {
                normalClearEnd.gameObject.SetActive(true);
            }
            else
            {
                normalFailEnd.gameObject.SetActive(true);
            }
        }
        else //게임타입이 시간제한모드인경우(구현예정)
        {
            
        }
       }
    //    (���� ���� < 1���ϸ�)
    //       
    //            Time.timeScale = 0;
    //          EndPanel.SetActive(true);
    //          GameEndTxt.gameObject.SetActive(true);
    //         GameEndTxt.text = "\n��ȸ�� ���� �����Ͽ����ϴ� ��^��";   // ���� �Ŵ������� ������ �����ϴ� ������ ������ �;ߵ�

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
}

