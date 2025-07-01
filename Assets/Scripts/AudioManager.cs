using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)  // �̱���
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���ξ� �Ѿ�� ��� �Ȳ�����
        }
        else Destroy(gameObject); 
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
    }
}
