using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Toggle bgmToggle; // 토글 값
    public Toggle modToggle; // 시간 제한 모드
    public GameObject Play; // 음악 켠 상태의 아이콘
    public GameObject Pause; // 음악 멈춘 상태의 아이콘

    public GameObject TitlePanel; //titleScene 기본 UI
    public GameObject CollectionPanel; // 컬렉션 패널 UI

    private void Start()
    {
        Invoke("Init", 0.1f);
    }
    private void Init()
    {
        if (AudioManager.Instance == null || AudioManager.Instance.audioSource == null)
        {
            Invoke("Init", 0.1f); // 계속 기다림
            return;
        }

        bgmToggle.onValueChanged.AddListener(BgmisOn);
        BgmisOn(bgmToggle.isOn);
    }

    public void BgmisOn(bool isOn) // 토글 상태 체크
    {
        if(isOn)
        {
            AudioManager.Instance.audioSource.Play(); // isOn 이 True 면 Play
            Play.SetActive(true);
            Pause.SetActive(false);
        }
        else
        {
            AudioManager.Instance.audioSource.Pause(); // isOn 이 False면 Pause
            Play.SetActive(false);
            Pause.SetActive(true);
        }
    }

    public void ModToggle()
    {
        bool isScoreMod = modToggle.isOn;
        GameManager.instance.SetStateToggle(isScoreMod);
        Debug.Log(GameManager.instance.TimeSet);
    }


    public void StartBtn() // 메인 씬 이동하는 버튼
    {
        SceneManager.LoadScene("MainScene");
        GameManager.instance.StartGame();
    }

    public void CollectionBtn() // 컬렉션 UI 버튼
    {
        TitlePanel.SetActive(false);
        CollectionPanel.SetActive(true);
    }
    
    public void BackFromCollectionBtn() // 컬렉션에서 뒤로가기 버튼
    {
        TitlePanel.SetActive(true);
        CollectionPanel.SetActive(false);
    }

    public void ExitBtn() // 게임 종료 버튼
    {
        Application.Quit();
    }
}
