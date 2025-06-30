using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Text Timetxt; // 위에 나오는 시간
    public Text ClearTime; // 클리어시 남은 시간
    public Text GameEndTxt; // 게임이 끝났을때 이긴건지 목숨이 다 된건지 혹은 시간이 다 된건지 보여주는 텍스트
    public GameObject EndPanel; // 게임이 끝나면 나오는 판넬

    private float time = 30f;
    private float Timer = 0f;
    void Start()
    {
        Timetxt.gameObject.GetComponent<Text>();
        ClearTime.gameObject.GetComponent<Text>();
        GameEndTxt.gameObject.GetComponent<Text>();
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
        ClearTime.text = time.ToString("N1");



        //if(time < 0f)
        //{
        //    End();
        //}
    }

    //    void End()
    //    {
    //            Time.timeScale = 0;
    //            EndPanel.SetActive(true);
    //            GameEndTxt.gameObject.SetActive(true);
    //            GameEndTxt.text = "시간이 다 되었습니다!!\n\n다시 도전?"; 

    //       

    //    }
    //}
    //    (남은 생명 < 1이하면)
    //       
    //            Time.timeScale = 0;
    //          EndPanel.SetActive(true);
    //          GameEndTxt.gameObject.SetActive(true);
    //         GameEndTxt.text = "\n기회를 전부 소진하였습니다 ㅠ^ㅠ";   // 게임 매니저에서 라이프 관리하는 변수를 가지고 와야됨

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void EndButton()
    {
        SceneManager.LoadScene("EndScene");
    }
}

