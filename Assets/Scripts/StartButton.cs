using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Toggle bgmToggle; // 토글 값
    public Toggle TimeMod; // 시간 제한 모드 객체
    public GameObject Play; // 음악 켠 상태의 아이콘
    public GameObject Pause; // 음악 멈춘 상태의 아이콘

    private void Start()
    {
        Invoke("Init", 0.1f); // 0.1초 뒤에 초기화
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
        if(AudioManager.Instance== null || AudioManager.Instance.audioSource == null)
        {
            Debug.Log("AudioManager 또는 AudioSource가 null입니다");
            return;
        }    

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

    // 시간 제한 모드랑 그냥 모드 구현되면 연결하기
    public void IsTimed(bool isOn)
    {
        if(isOn)
        {
            // 시간 제한 모드
        }
        else
        {
            // 그냥 모드
        }
    }

    public void StartBtn() // 메인 씬 이동하는 버튼
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CollectionBtn() // 컬렉션 UI 버튼
    {
        // 컬렉션 씬 열리게
        //.SetActive(true);
    }

    public void ExitBtn() // 게임 종료 버튼
    {
        Application.Quit();
    }
}
