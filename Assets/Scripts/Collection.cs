using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    //List<string> teamMembers = new List<string> {"Yejin", "YongMin", "Younga", "Youngsik"};
    
    public GameObject memberCard;

    public MemberInfoPanel infoPanel;

    public GameObject EmptyCollectionMessage;   //�÷��ǿ� �ƹ��� ������ �ߴ� �޽���
    public GameObject EmptyCollectionImage;   //�÷��ǿ� �ƹ��� ������ �ߴ� �̹���
    public GameObject HiddenStageBtn;   //�÷��� ��� ������ �ߴ� ���罺������ ��ư

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameManager.collectedCards.Count; i++)
        {
            GameObject go = Instantiate(memberCard, this.transform);

            float x = (i % GameManager.collectedCards.Count) * 1.4f - 2.1f;

            go.transform.position = new Vector2(x, 2.5f);
            go.GetComponent<MemberCard>().Setting(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        if (GameManager.collectedCards.Count == 0) //�ƹ��� ���� ������ ��
        {
            EmptyCollectionMessage.SetActive(true);
            EmptyCollectionImage.SetActive(true);
            HiddenStageBtn.SetActive(false);
        }
        else if (GameManager.collectedCards.Count == GameManager.teamMembers.Count) //���� ����� ��
        {
            EmptyCollectionMessage.SetActive(false);
            EmptyCollectionImage.SetActive(false);
            HiddenStageBtn.SetActive(true);
        }
    }

    private void OnDisable()
    {
        infoPanel.memberInfo.gameObject.SetActive(false);
        EmptyCollectionMessage.SetActive(false);
        HiddenStageBtn.SetActive(false);
    }
}
