using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    List<string> teamMembers = new List<string> {"Yejin", "YongMin", "Younga", "Youngsik"};
    
    public GameObject memberCard;

    public MemberInfoPanel infoPanel;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < teamMembers.Count; i++)
        {
            GameObject go = Instantiate(memberCard, this.transform);

            float x = (i % teamMembers.Count) * 1.4f - 2.1f;

            go.transform.position = new Vector2(x, 2.5f);
            go.GetComponent<MemberCard>().Setting(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        infoPanel.memberInfo.gameObject.SetActive(false);
    }
}
