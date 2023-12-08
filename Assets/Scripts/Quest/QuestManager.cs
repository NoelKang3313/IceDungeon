using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int, QuestData> questList;


    // ����Ʈ �Ҷ� ��Ÿ ���� ��� ���� �� Object
    public GameObject[] questObject;
    [Header("UI on/off")]
    public GameObject textBg;
    public GameObject btnBg;
    public bool choice = false;
    public int btnChoicNum = 0;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }
    
    void GenerateData()
    {
        questList.Add(10, new QuestData("���� Ÿ��ƲA", "Gm ������ \n Angel ������"
                                        , new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("���� Ÿ��ƲB", "Gm ������ ����"
                                        , new int[] { 3000, 1000 }));
        questList.Add(30, new QuestData("���� Ÿ��ƲC", "���� ����Ʈ!"
                                        , new int[] { 1000, 1000 }));
        questList.Add(40, new QuestData("���� Ÿ��ƲD", "���� ����Ʈ!"
                                        , new int[] { 1000, 1000 }));
        questList.Add(50, new QuestData("���� Ÿ��ƲE", "���� ����Ʈ!"
                                       , new int[] { 1000, 1000 }));
        questList.Add(60, new QuestData("���� Ÿ��ƲF", "���� ����Ʈ!"
                                       , new int[] { 1000, 1000 }));
        questList.Add(70, new QuestData("���� Ÿ��ƲG", "���� ����Ʈ!"
                               , new int[] { 1000, 1000 }));
        questList.Add(80, new QuestData("���� Ÿ��ƲH", "���� ����Ʈ!"
                       , new int[] { 1000, 1000 }));

        questList.Add(90, new QuestData("���� Ÿ��ƲI", "����Ʈ Ŭ����!", new int[] { 0 }));

    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }


        // ����Ʈ Ȱ��ȭ �� Ȱ��ȭ �Ǿ�� �Ұ�
        ControlObject();

        // ��ȭ �Ϸ� + ���� ����Ʈ
        if (questActionIndex >= questList[questId].npcId.Length && !choice)
        {
            NextQuest();
        }
        else if(choice)
        {
            ChoiceQuest(btnChoicNum==0?1:btnChoicNum);
        }

        UiActive();

        // ����Ʈ �̸� ��� 
        return questList[questId].questName;
    }

    public string CheckQuest()// ����Ʈ �̸� ��� 
    { return questList[questId].questName; }
    public String CheckQuestTitle()
    {
        return questList[questId].questTitle;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    public void ChoiceQuest(int number)
    {
        questId += 10*number;
        questActionIndex = 0;
        //ChoiceUISet(false); 
    }

    public void ChoiceUISet(bool p_flag)
    {
        textBg.gameObject.SetActive(!p_flag);
        btnBg.gameObject.SetActive(p_flag);
        choice = p_flag;
    }

    // �ʿ��� ��ǰ�̳� ������Ʈ���� ���� Ȥ�� ���ٶ�
    void ControlObject()
    {
        switch (questId)
        {
            case 10:

                if (questActionIndex == questList[questId].npcId.Length)
                {
                    questObject[0].SetActive(true);
                }
                break;
            case 20:
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    questObject[0].SetActive(false);
                }
                break;
            case 50:
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    ChoiceQuest(2);
                }
                break;
            case 60:
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    ChoiceQuest(2);
                }
                break;
            case 70:
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    ChoiceQuest(2);
                }
                break;
        }
    }

    //������ �ʿ��� ���� ��������
    void UiActive()
    {
        switch (questId)
        {
            case 30:
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    ChoiceUISet(true);
                    InteractionController.instance.Action();
                }
                break;
            case 40:
                ChoiceUISet(true);
                if (questActionIndex == questList[questId].npcId.Length)
                {
                    ChoiceUISet(false);
                }
                break;
            case 50:
                ChoiceUISet(false);

                break;
            case 60:
                ChoiceUISet(false);
                break;

        }
    }
}