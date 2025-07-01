using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public Text Timetxt; // ���� ������ �ð�
    public Text ClearTime; // Ŭ����� ���� �ð�
    public Text GameEndTxt; // ������ �������� �̱���� ����� �� �Ȱ��� Ȥ�� �ð��� �� �Ȱ��� �����ִ� �ؽ�Ʈ
    public GameObject EndPanel; // ������ ������ ������ �ǳ�

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
    //            GameEndTxt.text = "�ð��� �� �Ǿ����ϴ�!!\n\n�ٽ� ����?"; 

    //       

    //    }
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

    public void EndButton()
    {
        SceneManager.LoadScene("EndScene");
    }
}

