using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    // todo : 브금 나온거 꺼지게 혹은 켜지게

    // todo : 시간제한모드 들어가기 Setbool? 잘 모르겠다.

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
