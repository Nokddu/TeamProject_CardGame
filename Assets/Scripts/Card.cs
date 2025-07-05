using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip explosionSound;
    public AudioClip flipSound;
    public bool isBomb = false;
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator animator;

    public SpriteRenderer frontImage;

    private int numberOfImage = 4;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        GameManager.instance.allCards.Add(this);
    }

    void Update()
    {

    }

    public void Setting(int number)
    {
        idx = number;
        if (idx >= GameManager.teamMembers.Count * numberOfImage) // 팀멤버수*4이상의 인덱스는 폭탄 카드 
        {
            frontImage.sprite = Resources.Load<Sprite>("bomb");
            isBomb = true;
        }
        else//멤버 카드일 경우
        {
            string imageFile = GameManager.teamMembers[idx / numberOfImage] + "_" + (idx % numberOfImage + 1);
            frontImage.sprite = Resources.Load<Sprite>(imageFile);
            isBomb = false;
        }
    }

    public void OpenCard()
    {
        animator.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
        audioSource.PlayOneShot(flipSound);
        if (isBomb)//폭탄인지확인
        {
            GameManager.instance.DiscountTime(5f); // 시간 감소 처리
            Debug.Log("폭탄 카드 선택됨! 시간 -5초");
            audioSource.PlayOneShot(explosionSound);//폭발 사운드 출력
            Destroy(gameObject, 1f);
        }
        if (GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this;
        }
        else
        {
            GameManager.instance.secondCard = this;
            GameManager.instance.isMatched();
        }
    }
    public void ShowCardFace()//카드 앞면 보여주기
    {
        animator.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
    }

    public void HideCardFace()//카드 뒷면 보여주기
    {
        animator.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
    public void DestroyCard()
    {
        Invoke("DestoryCardInvoke", 1.0f);
    }
    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }
    void CloseCardInvoke()
    {
        animator.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
    public void BeforeCheck()
    {
        if (GameManager.instance.allOpen) return;
        if (Time.timeScale == 0f) return;
        OpenCard();
    }
}
