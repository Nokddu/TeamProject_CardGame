using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberInfoPanel : MonoBehaviour
{
    public int selectedMemberId = -1;

    List<string> teamMembers = new List<string> {"Yejin", "YongMin", "Younga", "Youngsik"};
    List<string> memberDescriptions = new List<string> {"안녕하세요 /예진", "안녕하세요/용민", "안녕하세요 /영아", "안녕하세요 /영식"};

    public Text nameText;
    public Text descriptionText;
    public SpriteRenderer memberImage1;
    public SpriteRenderer memberImage2;
    public SpriteRenderer memberImage3;

    public GameObject memberInfo;

    public void UpdateInfo(int idx)
    {
        selectedMemberId = idx;
        nameText.text = teamMembers[idx];
        descriptionText.text = memberDescriptions[idx];
        memberImage1.sprite = Resources.Load<Sprite>(teamMembers[idx]+"_"+1);
        memberImage2.sprite = Resources.Load<Sprite>(teamMembers[idx]+"_"+2);
        memberImage3.sprite = Resources.Load<Sprite>(teamMembers[idx]+"_"+3);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
