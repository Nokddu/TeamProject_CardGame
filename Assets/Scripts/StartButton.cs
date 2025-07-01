using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Toggle bgmToggle; // ��� ��
    public GameObject Play; // ���� �� ������ ������
    public GameObject Pause; // ���� ���� ������ ������

    private void Start()
    {
        bgmToggle.onValueChanged.AddListener(BgmisOn); // �Լ��� ����

        BgmisOn(bgmToggle.isOn); // ������ �� ��� ����ǰ�
    }

    public void BgmisOn(bool isOn) // ��� ���� üũ
    {
        if(isOn)
        {
            AudioManager.Instance.audioSource.Play(); // isOn �� True �� Play
            Play.SetActive(true);
            Pause.SetActive(false);
        }
        else
        {
            AudioManager.Instance.audioSource.Pause(); // isOn �� False�� Pause
            Play.SetActive(false);
            Pause.SetActive(true);
        }
    }

    // �ð� ���� ���� �׳� ��� �����Ǹ� �����ϱ�
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
