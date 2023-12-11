using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream:Assets/Scripts/EventManager.cs
=======
        interactionController = GetComponent<InteractionController>();
        interactionType = GetComponent<InteractionType>();
        talkManager = GameObject.Find("QuestManager").GetComponent<TalkManager>();
        questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
    }

    public void Start()
    {
        interactionController = GameObject.Find("Parm")?.GetComponent<InteractionController>();

        if (interactionController == null)
        {
            interactionController = GameObject.Find("Mao")?.GetComponent<InteractionController>();
        }
        questDetail.text =questManager.CheckQuest();
        questTitle.text =questManager.CheckQuestTitle();
    }


    // �� �ൿ�� �����ϸ�
    // ��ȭ�� �Ѵ�
    public void Action(GameObject _scanObject)
    {
        isAction = true;
        scanObject = _scanObject;
        interactionType = scanObject.GetComponent<InteractionType>();
        Talk(interactionType.id, interactionType.isNpc, interactionType.isPlayerTb);

        talkPanel.SetActive(isAction);
    }
    
    void Talk(int id, bool isNpc, bool isPlayerTb)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        Debug.Log($" id: {id} ,questTalkIndex: {questTalkIndex}, talkIndex: {talkIndex}");

        // Talk �����Ͱ� ���� ������ ���� ������
        // Talk �� ����
        if (talkData == null)
        {
            isAction = false;
            
            talkIndex = 0;
            Time.timeScale = 1;
            questDetail.text = questManager.CheckQuest(id);
            questTitle.text = questManager.CheckQuestTitle();
            return;
        }

        if (Time.timeScale != 0)
        {
            Time.timeScale = 0; 
        }

        // �̸��� ��ȭâ�� �����
        if (isNpc)
        {
            if (questManager.choice==false)
            {
                talkName.text = interactionType.GetName();
                talkText.text = talkData.Split(':')[0];
                talkImg.sprite = talkManager.GetPortait(id, int.Parse(talkData.Split(':')[1]));

            }
            else if(questManager.choice == true)
            {
                talkName.text = interactionType.GetName();
                btnint = talkData.Split(',').Length;
                for (int i = 0; i < talkData.Split(',').Length; i++)
                {
                    btnList[i].gameObject.SetActive(true);
                    btnList[i].gameObject.GetComponentInChildren<Text>().text = talkData.Split(",")[i];
                    // �� ��ư�� ���� �̺�Ʈ �߰�
                    int index = i; // �߿�: ���ٽ� ������ �ݺ� ������ ����� �� ���� ����
                    btnList[i].onClick.AddListener(() => OnClickButton(index));
                }
                for (int i = talkData.Split(',').Length; i < btnList.Length; i++)
                {
                    btnList[i].gameObject.SetActive(false);
                    btnList[i].gameObject.GetComponentInChildren<Text>().text = "";
                }
            }
            talkImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkName.text = interactionType.GetName();
            talkText.text = talkData;
            talkImg.color = new Color(1, 1, 1, 0);
        }
>>>>>>> Stashed changes:Assets/Scripts/Quest/EventManager.cs
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
