using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text Timetxt; // ���� ������ �ð�
    public Text ClearTime; // Ŭ����� ���� �ð�
    public Text GameEndTxt; // ������ �������� �̱���� ����� �� �Ȱ��� Ȥ�� �ð��� �� �Ȱ��� �����ִ� �ؽ�Ʈ
    public GameObject EndPanel; // ������ ������ ������ �ǳ�

    private float time = 5f;
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

        Timetxt.text = time.ToString("N1");
        ClearTime.text = time.ToString("N1");

        End();
    }

    void End()
    {
        if(time < 0f)
        {
            Time.timeScale = 0;
            EndPanel.SetActive(true);
            GameEndTxt.gameObject.SetActive(true);
            GameEndTxt.text = "�ð��� �� �Ǿ����ϴ�!!\n\n�ٽ� ����?"; 
        }
        //if( ���� ���� < 1���ϸ�)
        //{
        //    Time.timeScale = 0;
        //    EndPanel.SetActive(true);
        //    GameEndTxt.gameObject.SetActive(true);
        //    GameEndTxt.text = "\n��ȸ�� ���� �����Ͽ����ϴ� ��^��";   // ���� �Ŵ������� ������ �����ϴ� ������ ������ �;ߵ�
        //}

    }
}
