using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;
    
    public int cardCount = 0;
    
    private void Awake()
    {
        if(instance == null)
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
        if(firstCard.nameIndex == secondCard.nameIndex)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        
        firstCard = null;
        secondCard = null;
    }
}
