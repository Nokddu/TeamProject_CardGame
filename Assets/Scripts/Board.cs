using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    //public List<string> teamMembers = new List<string> {"Yejin", "YongMin", "Younga", "Youngsik"};


    Transform cards;
    public GameObject card;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int numOfPair = 8; //확장성 고려: 8이랑 10으로 넣었을 때 화면에 딱 맞음.
        List<int> cardIds = new List<int>();

        //각 멤버들의 1번 이미지를 1 Pair 넣어줌.
        for (int i = 0; i < GameManager.teamMembers.Count; i++)
        {
            cardIds.Add(i*3);
            cardIds.Add(i*3);
        }
    
        //cardIds의 갯수가 필요한 카드 갯수에 도달할때까지 반복
        while(cardIds.Count < numOfPair * 2 - 2)//폭탄 2장을위해-2제거
        {
            int randomNumber = Random.Range(0, GameManager.teamMembers.Count * 3); //멤버마다 이미지 3장
            
            //중복 체크 후 Add
            if(!cardIds.Contains(randomNumber))
            {
                cardIds.Add(randomNumber);
                cardIds.Add(randomNumber);
            }
        }
        
        int bombImageId = GameManager.teamMembers.Count * 3; //폭탄 추가
        cardIds.Add(bombImageId);
        cardIds.Add(bombImageId);


        cardIds = cardIds.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < numOfPair*2; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i / (numOfPair/2)) * 1.4f - 2.1f;
            float y = (i % (numOfPair/2)) * 1.4f - 3.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(cardIds[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}