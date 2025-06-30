using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public List<string> teamMembers = new List<string> {"Yejin", "YongMin", "Younga", "Pht", "Youngsik"};


    Transform cards;
    public GameObject card;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int numOfPair = 8; //8이랑 10으로 넣었을 때 화면에 딱 맞음.
        List<int> cardIds = new List<int>();

        //한명씩 제일 첫 이미지 넣어줌.
        for (int i = 0; i < teamMembers.Count; i++)
        {
            //각 멤버들의 1번 이미지를 넣어줌.
            cardIds.Add(i*3);
            cardIds.Add(i*3);
        }
    

//        Random random = new Random();
        while(cardIds.Count < numOfPair * 2)
        {
            int randomNumber = Random.Range(0,teamMembers.Count*3);
            
            if(!cardIds.Contains(randomNumber))
            {
                cardIds.Add(randomNumber);
                cardIds.Add(randomNumber);
            }
        }

        foreach (int ids in cardIds)
        {
            Debug.Log(ids);
        }

        cardIds = cardIds.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < numOfPair*2; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i / (numOfPair/2)) * 1.4f - 2.1f;
            float y = (i % (numOfPair/2)) * 1.4f - 3.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(cardIds[i]);
        }

        // for (int i = 0; i < 16; i++)
        // {
        //     GameObject go = Instantiate(card, this.transform);

        //     float x = (i / 4) * 1.4f - 2.1f;
        //     float y = (i % 4) * 1.4f - 3.0f;

        //     go.transform.position = new Vector2(x, y);
        //     go.GetComponent<Card>().Setting(cardIds[i]);
        // }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
