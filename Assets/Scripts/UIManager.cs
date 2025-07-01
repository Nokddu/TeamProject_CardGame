using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Text Timetxt; // ���� ������ �ð�
    public GameObject normalClearEnd; //노말게임 성공시 나오는 사진과 글
    public GameObject normalFailEnd;//노말게임 실패시 나오는 사진과 글
    public GameObject timerGameEnd;//시간 제한모드 게임 종료시 나오는 글
    public GameObject EndPanel; // ������ ������ ������ �ǳ�
    public string gameType = "Normal"; //타입 확인변수(나중에 게임매니저로 갈예정)

    private float time = 30f;
    private float Timer = 0f;
    void Start()
    {
        Timetxt.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        Timer += Time.deltaTime;
        float t = Mathf.Clamp01(Timer / time);
        float whitetored = Mathf.Lerp(1f, 0f, t);
        Timetxt.color = new Color(1f, whitetored, whitetored);
        Timetxt.text = time.ToString("N1");



        if(time < 0f)
        {
           End();
        }
    }

       void End()
       {
        Time.timeScale = 0;
        EndPanel.SetActive(true);
        if (gameType == "Normal")
        {
            if (time > 0)
            {
                normalClearEnd.gameObject.SetActive(true);
            }
            else
            {
                normalFailEnd.gameObject.SetActive(true);
            }
        }
       }
    //}
    //    (���� ���� < 1���ϸ�)
    //       
    //            Time.timeScale = 0;
    //          EndPanel.SetActive(true);
    //          GameEndTxt.gameObject.SetActive(true);
    //         GameEndTxt.text = "\n��ȸ�� ���� �����Ͽ����ϴ� ��^��";   // ���� �Ŵ������� ������ �����ϴ� ������ ������ �;ߵ�

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MoveTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void EndButton() //실제로는 게임 종료되지만 화면상에는 안꺼짐
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}

