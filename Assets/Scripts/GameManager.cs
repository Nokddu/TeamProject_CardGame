using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;
    public bool allOpen = false;
    public int cardCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {


    }

    public void isMatched()
    {
        allOpen = true;
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            Invoke(nameof(EnableClick), 1.0f);

            if (cardCount == 0)
            { // 카드를 모두 찾을시
                Time.timeScale = 0.0f;
                Invoke("EndButton", 1.0f);
            }

        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();

            Invoke(nameof(EnableClick), 1.0f);

        }


        firstCard = null;
        secondCard = null;

        allOpen = true;



    }

    void EnableClick()
    {
        allOpen = false;
    }
}

