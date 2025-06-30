using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public List<string> teamMembers = new List<string> {"Yejin", "YongMin", "Younga", "Yongjin", "Youngsik"};

    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator animator;

    public SpriteRenderer frontImage;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Setting(int number)
    {
        idx = number;
        string imageFile = teamMembers[idx/3] + "_" + (idx%3+1);
        //이름 + "_" + 번호 //이름: idx/3 몫 //번호: idx%3 나머지 +1
        Debug.Log(imageFile);
        
        frontImage.sprite = Resources.Load<Sprite>(imageFile);
    }

    public void OpenCard()
    {
        animator.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if(GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this;
        }
        else
        {
            GameManager.instance.secondCard = this;
            GameManager.instance.isMatched();
        }
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

}
