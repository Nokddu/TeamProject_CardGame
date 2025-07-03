using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    List<string> teamMembers = new List<string> {"Yejin", "YongMin", "Younga", "Youngsik"};
    private AudioSource audioSource;
    public AudioClip explosionSound;
    bool isBomb = false;
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator animator;

    public SpriteRenderer frontImage;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {   if(!GameManager.instance.allCards.Contains(this))
        {
            GameManager.instance.allCards.Add(this);
        }
    }

    void Update()
    {

    }

    public void Setting(int number)
    {
        idx = number;
        if (idx >= teamMembers.Count * 3) // 팀멤버수*3이상의 인덱스는 폭탄 카드
        {
            frontImage.sprite = Resources.Load<Sprite>("bomb");
            isBomb = true;
        }
        else//멤버 카드일 경우
        {
            string imageFile = teamMembers[idx / 3] + "_" + (idx % 3 + 1);
            frontImage.sprite = Resources.Load<Sprite>(imageFile);
            isBomb = false;
        }
    }

    public void OpenCard()
    {
        animator.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
        if (idx == 12)//폭탄인지확인
        {
            GameManager.instance.DiscountTime(5f); // 시간 감소 처리
            Debug.Log("폭탄 카드 선택됨! 시간 -5초");
            audioSource.PlayOneShot(explosionSound);//폭발 사운드 출력
            DestoryCardInvoke();
        }
        if (GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this;
            if(idx == 12)
            {
                GameManager.instance.firstCard = null;
            }
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
        gameObject.SetActive(false);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }
    public void CloseCardInvoke()
    {
        animator.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
    public void BeforeCheck()
    {
        if (GameManager.instance.allOpen) return;
        OpenCard();
    }

    public void SetactiveInvoke()
    {
        Invoke("Setactive", 2f);
    }

    private void Setactive()
    {
        gameObject.SetActive(true);
    }
}
