using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberCard : MonoBehaviour
{
    public int idx = 0;

    public SpriteRenderer memberImage;

    public MemberInfoPanel infoPanel;  // 패널 연결

    bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        if (infoPanel == null)
        {
            infoPanel = FindObjectOfType<MemberInfoPanel>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (infoPanel.selectedMemberId != this.idx)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
            isSelected = false;
        }
        else if (infoPanel.selectedMemberId == -1)
        {
            infoPanel.memberInfo.gameObject.SetActive(false);
            isSelected = false;
        }
    }

    public void Setting(int number)
    {
        idx = number;
        
        memberImage.sprite = Resources.Load<Sprite>(GameManager.collectedCards[idx]+"_"+1);

        Debug.Log(idx+"생성됨");
    }

    public void Selected()
    {
        if(isSelected)
        {
            Debug.Log(GameManager.collectedCards[this.idx]+"선택또함!");
            
            GetComponent<SpriteRenderer>().color = Color.black;
            infoPanel.memberInfo.gameObject.SetActive(false);
            this.isSelected = false;

        }
        else
        {
            Debug.Log(GameManager.collectedCards[this.idx]+"선택함!");

            GetComponent<SpriteRenderer>().color = Color.white;
            infoPanel.UpdateInfo(this.idx);
            infoPanel.memberInfo.gameObject.SetActive(true);
            this.isSelected = true;
        }
    }
}
