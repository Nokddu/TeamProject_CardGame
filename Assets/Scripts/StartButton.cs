using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Toggle bgmToggle; // ��� ��
    public Toggle TimeMod; // �ð� ���� ��� ��ü
    public GameObject Play; // ���� �� ������ ������
    public GameObject Pause; // ���� ���� ������ ������

    private void Start()
    {
        Invoke("Init", 0.1f); // 0.1�� �ڿ� �ʱ�ȭ
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
        if(AudioManager.Instance== null || AudioManager.Instance.audioSource == null)
        {
            Debug.Log("AudioManager �Ǵ� AudioSource�� null�Դϴ�");
            return;
        }    

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
