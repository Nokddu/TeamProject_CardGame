using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberInfoPanel : MonoBehaviour
{
    public int selectedMemberId = -1;

    List<string> teamMembers = new List<string> {"Yejin", "YongMin", "Younga", "Youngsik"};
    List<string> memberDescriptions = new List<string> {"안녕하세요 /예진", "안녕하세요/용민", "안녕하세요 /영아", "안녕하세요 /영식"};
    List<string> collectedCards = new List<string>(); //수집된 멤버들 add 될 예정.


    public Text nameText;
    public Text descriptionText;
    public SpriteRenderer memberImage1;
    public SpriteRenderer memberImage2;
    public SpriteRenderer memberImage3;

    public GameObject memberInfo;

    public void UpdateInfo(int idx)
    {
        if (collectedCards.Contains(teamMembers[idx]))
        {
            selectedMemberId = idx;
            nameText.text = teamMembers[idx];
            descriptionText.text = memberDescriptions[idx];
            memberImage1.sprite = Resources.Load<Sprite>(teamMembers[idx] + "_" + 1);
            memberImage2.sprite = Resources.Load<Sprite>(teamMembers[idx] + "_" + 2);
            memberImage3.sprite = Resources.Load<Sprite>(teamMembers[idx] + "_" + 3);
            Debug.Log("획득멤버");
        }
        else
        {
            selectedMemberId = idx;
            nameText.text = teamMembers[idx];
            descriptionText.text = "...";
            memberImage1.sprite = Resources.Load<Sprite>("bomb");
            memberImage2.sprite = Resources.Load<Sprite>("bomb");
            memberImage3.sprite = Resources.Load<Sprite>("bomb");
            Debug.Log("미획득멤버");
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

    public void CollectOne(string memberName)
    {
        //모든 카드가 콜렉트 된 상태가 아닐 경우에만
        if (!(collectedCards.Count == teamMembers.Count))
        {
            collectedCards.Add(memberName);
            Debug.Log(memberName);
            foreach (string name in collectedCards)
            {
                Debug.Log(name);
            }
            Debug.Log("CollectOne from infoPanel called");
        }
    }
}
