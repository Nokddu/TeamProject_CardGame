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

    public GameObject TitlePanel; //titleScene �⺻ UI
    public GameObject CollectionPanel; // �÷��� �г� UI

    private void Start()
    {
        Invoke("Init", 0.1f);
    }
    private void Init()
    {
        if (AudioManager.Instance == null || AudioManager.Instance.audioSource == null)
        {
            Invoke("Init", 0.1f); // ��� ��ٸ�
            return;
        }

        bgmToggle.onValueChanged.AddListener(BgmisOn);
        BgmisOn(bgmToggle.isOn);
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
        TitlePanel.SetActive(false);
        CollectionPanel.SetActive(true);
    }
    
    public void BackFromCollectionBtn() // �÷��ǿ��� �ڷΰ��� ��ư
    {
        TitlePanel.SetActive(true);
        CollectionPanel.SetActive(false);
    }

    public void ExitBtn() // ���� ���� ��ư
    {
        Application.Quit();
    }
}
