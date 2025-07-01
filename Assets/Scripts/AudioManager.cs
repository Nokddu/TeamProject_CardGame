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
        if (Instance == null)  // ½Ì±ÛÅæ
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ¸ÞÀÎ¾À ³Ñ¾î°¡µµ ºê±Ý ¾È²¨Áö°Ô
        }
        else Destroy(gameObject); 
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
    }
}
