using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    // todo : ��� ���°� ������ Ȥ�� ������

    // todo : �ð����Ѹ�� ���� Setbool? �� �𸣰ڴ�.

    public void IsTimed(bool isOn)
    {
        if(isOn)
        {
            // �ð� ���� ���
        }
        else
        {
            // �׳� ���
        }
    }

    public void StartBtn() // ���� �� �̵��ϴ� ��ư
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CollectionBtn() // �÷��� UI ��ư
    {
        // �÷��� �� ������
        //.SetActive(true);
    }

    public void ExitBtn() // ���� ���� ��ư
    {
        Application.Quit();
    }
}
