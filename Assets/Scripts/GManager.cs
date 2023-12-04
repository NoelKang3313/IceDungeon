using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    InteractionType interactionType;
    public TalkManager talkManager;
    // ��ȭâ
    [Header ("TalkDateWrite")]
    public GameObject talkPanel;
    public Text talkText;
    public Text talkName;
    public Image talkImg;

    public GameObject scanObject;
    public bool isAction = false;
    public int talkIndex;


    // �� �ൿ�� �����ϸ�
    // ��ȭ�� �Ѵ�
    public void Action(GameObject _scanObject)
    {
        isAction = true;
        scanObject = _scanObject;
        interactionType = scanObject.GetComponent<InteractionType>();
        Talk(interactionType.id, interactionType.isNpc);

        talkPanel.SetActive(isAction);
        
    }
    
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        // Talk �����Ͱ� ���� ������ ���� ������
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Time.timeScale = 1;
            return;
        }
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0; 
        }

        // �̸��� ��ȭâ�� �����
        if (isNpc)
        {
            talkName.text = interactionType.GetName();
            talkText.text = talkData.Split(':')[0];
            Debug.Log(talkData.Split(':')[0]);
            talkImg.sprite = talkManager.GetPortait(id,int.Parse(talkData.Split(':')[1]));
            Debug.Log(talkData.Split(':')[1]);

        }
        else
        {
            talkName.text = interactionType.GetName();
            talkText.text = talkData;
        }

        isAction = true;
        talkIndex++;
    }

}
