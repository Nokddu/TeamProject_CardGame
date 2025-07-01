using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static string gameType = "Normal";
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
            if(firstCard.idx == 0 && secondCard.idx == 0)
            {
                UIManager ui = GetComponent<UIManager>();
                ui.GetComponent<UIManager>().time -= 1f;
                Debug.Log("시간이" + ui.time + "만큼 남았어요");
            }

            if (cardCount == -16)
            { // 카드를 모두 찾을시
                UIManager.uiInstance.End();
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

